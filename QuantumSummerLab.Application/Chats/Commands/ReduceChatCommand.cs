using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Application.Chats.Commands;

public class ReduceChatCommand : IRequest<ReduceChatResponse>
{
    public string TeamName { get; set; }
    public Guid[] ChatsToReduce { get; set; }
    public string ReducedMessage { get; set; }
    public int TokensUsed { get; set; }
}

public class ReduceChatResponse
{
}

public class ReduceChatCommandHandler : IRequestHandler<ReduceChatCommand, ReduceChatResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ReduceChatCommandHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<ReduceChatResponse> Handle(ReduceChatCommand request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var team = await dbContext.Teams.SingleOrDefaultAsync(
            x => x.Name == request.TeamName, cancellationToken);

        var chatsToReduce = await dbContext.Chats
            .Where(x => request.ChatsToReduce.Contains(x.Id))
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync(cancellationToken);

        chatsToReduce.ForEach(chat => chat.IsReduced = true);

        dbContext.Chats.Add(new Chat
        {
            Role = "Reduced",
            Message = request.ReducedMessage,
            TokensUsed = request.TokensUsed,
            Team = team,
            Timestamp = chatsToReduce.First().Timestamp
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ReduceChatResponse();
    }
}