using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Application.Chats.Commands;

public class SaveChatCommand : IRequest<SaveChatResponse>
{
    public string TeamName { get; set; }
    public string Message { get; set; }
    public string Role { get; set; }
    public int TokensUsed { get; set; }
}

public class SaveChatResponse
{
}

public class SaveChatCommandHandler : IRequestHandler<SaveChatCommand, SaveChatResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SaveChatCommandHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<SaveChatResponse> Handle(SaveChatCommand request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var team = await dbContext.Teams.SingleOrDefaultAsync(
            x => x.Name == request.TeamName, cancellationToken);

        dbContext.Chats.Add(new Chat
        {
            Role = request.Role,
            Message = request.Message,
            TokensUsed = request.TokensUsed,
            Team = team,
            Timestamp = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return new SaveChatResponse();
    }
}