using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Chats.Commands;

public class ClearChatCommand : IRequest<ClearChatResponse>
{
    public string TeamName { get; set; }
}

public class ClearChatResponse
{

}

public class ClearChatCommandHandler : IRequestHandler<ClearChatCommand, ClearChatResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ClearChatCommandHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<ClearChatResponse> Handle(ClearChatCommand request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        await dbContext.Chats.Where(x => x.Team.Name == request.TeamName).ExecuteUpdateAsync(x => x.SetProperty(p => p.IsDeleted, true), cancellationToken);

        return new ClearChatResponse();
    }
}