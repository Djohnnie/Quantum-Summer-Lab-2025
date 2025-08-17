using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Chats.Queries;

public class GetChatsQuery : IRequest<GetChatsResponse>
{
    public string TeamName { get; set; }
    public bool ShouldIncludeDeleted { get; set; }
}

public class GetChatsResponse
{
    public List<ChatMessage> Messages { get; set; }
}

public class ChatMessage
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Role { get; set; }
    public int TokensUsed { get; set; }
    public bool IsReduced { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime Timestamp { get; set; }
}

public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, GetChatsResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetChatsQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetChatsResponse> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var messages = await dbContext.Chats
            .Where(x => x.Team.Name == request.TeamName)
            .Where(x => request.ShouldIncludeDeleted || !x.IsDeleted)
            .OrderBy(x => x.Timestamp)
            .Select(x => new ChatMessage
            {
                Id = x.Id,
                Role = x.Role,
                Message = x.Message,
                TokensUsed = x.TokensUsed,
                IsReduced = x.IsReduced,
                IsDeleted = x.IsDeleted,
                Timestamp = x.Timestamp
            })
            .ToListAsync(cancellationToken);

        return new GetChatsResponse
        {
            Messages = messages
        };
    }
}