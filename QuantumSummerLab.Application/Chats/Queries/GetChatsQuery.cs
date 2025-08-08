using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Chats.Queries;

public class GetChatsQuery : IRequest<GetChatsResponse>
{
    public string TeamName { get; set; }
}

public class GetChatsResponse
{
    public List<ChatMessage> Messages { get; set; }
}

public class ChatMessage
{
    public string Message { get; set; }
    public string Role { get; set; }
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
            .OrderBy(x => x.Timestamp)
            .Select(x => new ChatMessage
            {
                Role = x.Role,
                Message = x.Message
            })
            .ToListAsync(cancellationToken);

        return new GetChatsResponse
        {
            Messages = messages
        };
    }
}