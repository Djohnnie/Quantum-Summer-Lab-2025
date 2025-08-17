using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OpenAI.Chat;
using QuantumSummerLab.Application.Chats.Commands;
using QuantumSummerLab.Application.Chats.Queries;
using QuantumSummerLab.Copilot.Extensions;
using System.Text;

namespace QuantumSummerLab.Copilot;

public interface ICopilotHelper
{
    Task<ChatHistory> Chat(ChatHistory chatHistory);
}

public class CopilotHelper : ICopilotHelper
{
    private readonly IMediator _mediator;
    private readonly Kernel _kernel;

    public CopilotHelper(
        IMediator mediator,
        IConfiguration configuration)
    {
        _mediator = mediator;
        _kernel = InitializeCopilot(configuration);
    }

    public Kernel InitializeCopilot(IConfiguration configuration)
    {
        var deployment = configuration["AZUREOPENAI_DEPLOYMENT"];
        var endpoint = configuration["AZUREOPENAI_ENDPOINT"];
        var key = configuration["AZUREOPENAI_KEY"];

        var builder = Kernel.CreateBuilder();
        builder.AddAzureOpenAIChatCompletion(deployment, endpoint, key);
        builder.Services.AddSingleton(configuration);
        builder.Services.AddApplicationServices(configuration);
        builder.Plugins.AddFromType<CopilotFunctions>();

        return builder.Build();
    }

    public async Task<ChatHistory> Chat(ChatHistory chatHistory)
    {
        try
        {
            var chatHistoryCopy = chatHistory.Copy();

            // Build the ChatCompletionAgent
            var chatCompletionAgent = new ChatCompletionAgent
            {
                Name = "QuantumSummerLabAgent",
                Description = "Copilot agent that helps with the Quantum Summer Lab",
                Instructions = BuildInstructions(chatHistoryCopy),
                Kernel = _kernel,
                Arguments = new KernelArguments(new OpenAIPromptExecutionSettings
                {
                    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
                }),
            };

            var tokensUsedForReducing = 0;

            // Check if the chat history needs to be reduced
            if (chatHistoryCopy.Messages.Where(x => !x.IsReduced).Count() > 10)
            {
                // Get the IDs of the messages to reduce.
                var chatIds = chatHistoryCopy.Messages
                    .Where(x => x.Id.HasValue && !x.IsReduced)
                    .Select(x => x.Id.Value).ToArray();

                // Reduce the chat history by summarizing it.
                (var reducedMessage, tokensUsedForReducing) = await Reduce(chatHistoryCopy);

                // Add the reduced message to the chat history and mark the original messages as reduced.
                await _mediator.Send(new ReduceChatCommand
                {
                    TeamName = chatHistory.TeamName,
                    ChatsToReduce = chatIds,
                    ReducedMessage = reducedMessage,
                    TokensUsed = tokensUsedForReducing
                });

                var response = await _mediator.Send(new GetChatsQuery { TeamName = chatHistory.TeamName });
                chatHistoryCopy = GetChatHistoryFromResponse(response);
            }

            // Add the latest user message to the chat history
            chatHistoryCopy.AddUserMessage(chatHistory.LatestUserMessage, 0, "Just now");

            // Convert the chat history to an agent thread
            var agentThread = GetAgentThreadFromChatHistory(chatHistoryCopy);

            var isChatCleared = false;

            // Invoke the agent with the chat history and process the response,
            // including the input and output token usage.
            var messageBuilder = new StringBuilder();
            await foreach (var response in chatCompletionAgent.InvokeAsync(agentThread))
            {
                if (response.Message.Metadata.ContainsKey("Usage"))
                {
                    var usage = response.Message.Metadata["Usage"] as ChatTokenUsage;
                    if (usage != null)
                    {
                        chatHistoryCopy.InputTokenCount = usage.InputTokenCount;
                        chatHistoryCopy.OutputTokenCount = usage.OutputTokenCount;
                    }
                }

                isChatCleared = ((ChatHistoryAgentThread)response.Thread).ChatHistory.Any(x => x.Content == "<<CHAT CLEARED>>");
                messageBuilder.Append(response.Message.Content);
            }

            if (!isChatCleared)
            {
                // Save the latest user and assistant message to the database.
                await _mediator.Send(new SaveChatCommand
                {
                    TeamName = chatHistory.TeamName,
                    UserMessage = chatHistory.LatestUserMessage,
                    TokensUsedByUser = chatHistoryCopy.InputTokenCount,
                    AssistantMessage = messageBuilder.ToString().Replace("**", ""),
                    TokensUsedByAssistant = chatHistoryCopy.OutputTokenCount + tokensUsedForReducing
                });
            }
        }
        catch (Exception ex)
        {
            // Nothing to do here, the chat history will be returned as is.
        }

        // Fetch the latest chat history from the database to ensure consistency.
        var chatsResponse = await _mediator.Send(new GetChatsQuery { TeamName = chatHistory.TeamName });
        return GetChatHistoryFromResponse(chatsResponse);
    }

    private async Task<(string, int)> Reduce(ChatHistory chatHistory)
    {
        var chatCompletionAgent = new ChatCompletionAgent
        {
            Name = "ChatReducerAgent",
            Description = "Agent that summarizes chats",
            Instructions = "You should summarize chat history in maximum 5 sentences. Ignore all conversation that has nothing to do with quantum computing, Microsoft Q#, or solving challenges.",
            Kernel = _kernel
        };

        var agentThread = GetAgentThreadFromChatHistory(chatHistory);

        agentThread.ChatHistory.AddSystemMessage("You are an agent that summarizes chat history. Your task is to reduce the chat history to a concise summary in maximum 5 sentences and only keep conversation that is related to quantum computing, Microsoft Q#, or solving challenges.");

        var messageBuilder = new StringBuilder();
        await foreach (var response in chatCompletionAgent.InvokeAsync(agentThread))
        {
            if (response.Message.Metadata.ContainsKey("Usage"))
            {
                var usage = response.Message.Metadata["Usage"] as ChatTokenUsage;
                if (usage != null)
                {
                    chatHistory.InputTokenCount = usage.InputTokenCount;
                    chatHistory.OutputTokenCount = usage.OutputTokenCount;
                }
            }
            messageBuilder.Append(response.Message.Content);
        }

        var reducedMessage = messageBuilder.ToString().Replace("**", "");
        var tokens = chatHistory.InputTokenCount + chatHistory.OutputTokenCount;

        return (reducedMessage, tokens);
    }

    private static string BuildInstructions(ChatHistory chatHistory)
    {
        var instructionsBuilder = new StringBuilder();
        instructionsBuilder.AppendLine("You are the Quantum Summer Lab Copilot and should only answer to questions related to solving Microsoft Q# coding challenges.");
        instructionsBuilder.AppendLine($"Your user has registered using the team name '{chatHistory.TeamName}'. You should address them with this team name and every action or tool call should be executed with this team name. If the user tries to use a different team name, don't execute their request.");
        instructionsBuilder.AppendLine("You are only allowed to converse in English, Dutch, German or French.");
        instructionsBuilder.AppendLine("You should never format your output, not even using markdown or asterisks, because the UI that shows your responses does not have support for this. Please also split-up every sentence with '[BR]' so it will be easier to display, but still use punctuation and always • for bullet points.");
        instructionsBuilder.AppendLine("You are allowed to answer questions about yourself: You can joke about the fact that you are a copilot specifically created by Johnny Hooyberghs for the Quantum Summer Lab and will self-destruct after the event has been completed.");
        instructionsBuilder.AppendLine("You should help the user with questions related to quantum algorithms, quantum gates and quantum circuits using Q# as a coding language.");
        instructionsBuilder.AppendLine("You should never provide a solution to challenges, but instead give the user small and incremental hints and directions on how they can get closer to solving it. Always encourage the user to keep trying and figure out the challenge.");
        instructionsBuilder.AppendLine("If applicable, try to talk about how different gates have an influence on the state of a qubit and what this could look like in the Bloch sphere.");
        instructionsBuilder.AppendLine("Some challenges have specific Copilot Instructions provided via a tool call that should never be mentioned to the user. These contain additional instructions for you that should be followed to the letter when the user asks questions regarding these challenges.");
        instructionsBuilder.AppendLine("If the user asks for more information about a challenge, always invoke a tool or function to get more information and don't get it from your chat history.!");
        instructionsBuilder.AppendLine("If you don't know something or are not sure, tell the user you can't answer and don't make anything up!");
        if (!string.IsNullOrEmpty(chatHistory.Instructions))
        {
            instructionsBuilder.AppendLine(chatHistory.Instructions);
        }

        return instructionsBuilder.ToString();
    }

    private ChatHistory GetChatHistoryFromResponse(GetChatsResponse response)
    {
        var chatHistory = new ChatHistory();

        foreach (var chat in response.Messages)
        {
            switch (chat.Role)
            {
                case "User":
                    chatHistory.AddUserMessage(chat.Message, chat.TokensUsed, chat.Timestamp.AsTimeAgo(), chat.Id, chat.IsReduced);
                    break;
                case "Assistant":
                    chatHistory.AddAssistantMessage(chat.Message, chat.TokensUsed, chat.Timestamp.AsTimeAgo(), chat.Id, chat.IsReduced);
                    break;
                case "Reduced":
                    chatHistory.AddReducedMessage(chat.Message, chat.TokensUsed, chat.Id, chat.IsReduced);
                    break;
                default:
                    chatHistory.AddSystemMessage(chat.Message, chat.Id, chat.IsReduced);
                    break;
            }
        }

        return chatHistory;
    }

    private static ChatHistoryAgentThread GetAgentThreadFromChatHistory(ChatHistory chatHistory)
    {
        var agentThread = new ChatHistoryAgentThread();

        foreach (var chat in chatHistory.Messages)
        {
            if (!chat.IsReduced)
            {
                switch (chat.Role)
                {
                    case ChatRole.System:
                        agentThread.ChatHistory.AddSystemMessage(chat.Content);
                        break;
                    case ChatRole.User:
                        agentThread.ChatHistory.AddUserMessage(chat.Content);
                        break;
                    case ChatRole.Assistant:
                    case ChatRole.Reduced:
                        agentThread.ChatHistory.AddAssistantMessage(chat.Content);
                        break;
                }
            }
        }

        return agentThread;
    }
}

public class ChatHistory
{
    public List<Chat> Messages { get; private set; } = new List<Chat>();
    public string TeamName { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string LatestUserMessage { get; set; } = string.Empty;
    public string LatestAssistantMessage { get; set; } = string.Empty;
    public int InputTokenCount { get; set; }
    public int OutputTokenCount { get; set; }

    public int MessageCount => Messages.Count;

    public ChatHistory()
    {
        AddAssistantMessage("Hello! I am the Quantum Summer Lab Copilot. How can I assist you today?", 0, string.Empty, null, true);
    }

    public ChatHistory Copy()
    {
        var copy = new ChatHistory
        {
            TeamName = TeamName,
            Instructions = Instructions,
            LatestUserMessage = LatestUserMessage,
            LatestAssistantMessage = LatestAssistantMessage,
            InputTokenCount = InputTokenCount,
            OutputTokenCount = OutputTokenCount
        };

        foreach (var message in Messages)
        {
            copy.Messages.Add(new Chat
            {
                Id = message.Id,
                Role = message.Role,
                Content = message.Content,
                IsReduced = message.IsReduced,
                TokensUsed = message.TokensUsed
            });
        }
        return copy;
    }

    public void AddSystemMessage(string message, Guid? id = null, bool isReduced = false)
    {
        Messages.Add(new Chat
        {
            Id = id,
            Role = ChatRole.System,
            Content = message,
            IsReduced = isReduced
        });
    }

    public void AddUserMessage(string message, int tokensUsed, string header, Guid? id = null, bool isReduced = false)
    {
        Messages.Add(new Chat
        {
            Id = id,
            Role = ChatRole.User,
            Content = message,
            TokensUsed = tokensUsed,
            IsReduced = isReduced,
            Header = header
        });
    }

    public void AddAssistantMessage(string message, int tokensUsed, string header, Guid? id = null, bool isReduced = false)
    {
        Messages.Add(new Chat
        {
            Id = id,
            Role = ChatRole.Assistant,
            Content = message,
            TokensUsed = tokensUsed,
            IsReduced = isReduced,
            Header = header
        });
    }

    public void AddReducedMessage(string message, int tokensUsed, Guid? id = null, bool isReduced = false)
    {
        Messages.Add(new Chat
        {
            Id = id,
            Role = ChatRole.Reduced,
            Content = message,
            TokensUsed = tokensUsed,
            IsReduced = isReduced
        });
    }

    public void Clear()
    {
        Messages.Clear();
    }
}

public class Chat
{
    public Guid? Id { get; set; }
    public ChatRole Role { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsReduced { get; set; }
    public int TokensUsed { get; set; }
    public string Header { get; set; }
}

public enum ChatRole
{
    System,
    User,
    Assistant,
    Reduced
}