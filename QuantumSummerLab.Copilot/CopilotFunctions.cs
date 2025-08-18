using MediatR;
using Microsoft.SemanticKernel;
using QuantumSummerLab.Application.Challenges.Queries;
using QuantumSummerLab.Application.Chats.Commands;
using QuantumSummerLab.Application.Scores.Queries;
using System.ComponentModel;
using System.Text;

namespace QuantumSummerLab.Copilot;

public class CopilotFunctions
{
    private readonly IMediator _mediator;

    public CopilotFunctions(IMediator mediator)
    {
        _mediator = mediator;
    }

    [KernelFunction]
    [Description("Gets more information about a challenge with a specific name.")]
    [return: Description("The name, title, level, full description and the signature of the operation that needs to be written to complete the challenge.")]
    public async Task<string> GetChallengeInformation([Description("The name of the challenge to get the information for [0, A1, A2, A3, B1, B2, B3, C1, C2, C3, D1, D2, D3]")] string challengeName)
    {
        var challenge = await _mediator.Send(new GetChallengeByNameQuery { ChallengeName = challengeName });
        if (!challenge.IsAvailable)
        {
            return $"There is no challenge with the name '{challengeName}'.";
        }

        var responseBuilder = new StringBuilder();
        responseBuilder.AppendLine($"**{challenge.Name}**");
        responseBuilder.AppendLine($"**Title: {challenge.Title}**");
        responseBuilder.AppendLine($"**Level: {challenge.Level}**");
        responseBuilder.AppendLine($"**Description: {challenge.Description.Replace("[BR]", "")}**");
        responseBuilder.AppendLine($"**Solution Template**");
        responseBuilder.AppendLine(challenge.SolutionTemplate);
        if (string.IsNullOrEmpty(challenge.CopilotInstructions))
        {
            responseBuilder.AppendLine($"**Copilot Instructions that should never be mentioned to the user: {challenge.CopilotInstructions}* *");
        }
        return responseBuilder.ToString();
    }

    [KernelFunction]
    [Description("Get information about the leaderboard.")]
    [return: Description("The position, team name, total score and some additional comments for all participants.")]
    public async Task<string> GetMyLeaderboardPosition()
    {
        var leaderboard = await _mediator.Send(new GetLeaderboardQuery());

        var responseBuilder = new StringBuilder();
        foreach (var entry in leaderboard.Entries)
        {
            responseBuilder.AppendLine($"|position: {entry.Position}|team name: {entry.TeamName}|score: {entry.TotalPoints}|challenges completed: {entry.ChallengesCompleted}|total number of tries: {entry.ChallengesTried}|");
        }
        return responseBuilder.ToString();
    }

    [KernelFunction]
    [Description("Gets the latest proposal for a specific team name and challenge name.")]
    [return: Description("The submitted code by the team for the specific challenge.")]
    public async Task<string> GetMyLatestProposal([Description("The name of the team that submitted the code.")] string teamName, [Description("The name of the challenge to get the submitted code for.")] string challengeName)
    {
        var proposals = await _mediator.Send(new GetYourSubmissionsQuery
        {
            TeamName = teamName,
            ChallengeName = challengeName
        });

        var latestProposal = proposals.YourSubmissions
            .OrderByDescending(x => x.SubmissionTimestamp)
            .FirstOrDefault();

        if (latestProposal == null)
        {
            return "No proposals found for this challenge.";
        }

        var responseBuilder = new StringBuilder();
        responseBuilder.AppendLine($"**Your submission is {(latestProposal.IsSuccessful ? "correct" : "not correct")}**");
        responseBuilder.AppendLine($"**Submission**");
        responseBuilder.AppendLine(latestProposal.ProposedSolution);
        return responseBuilder.ToString();
    }

    [KernelFunction]
    [Description("Clear the chat history for a specific team.")]
    [return: Description("A code that needs to be sent to the user after clearing has completed.")]
    public async Task<string> ClearMyChatHistory([Description("The name of the team that would like to have its chat history cleared.")] string teamName)
    {
        await _mediator.Send(new ClearChatCommand { TeamName = teamName });

        return "<<CHAT CLEARED>>";
    }
}