using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Teams.Commands;

public class ArchiveTeamCommand : IRequest<Unit>
{
    public Guid TeamId { get; set; }
}

public class ArchiveTeamCommandHandler : IRequestHandler<ArchiveTeamCommand, Unit>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ArchiveTeamCommandHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Unit> Handle(ArchiveTeamCommand request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        await dbContext.Teams.Where(x => x.Id == request.TeamId).ExecuteUpdateAsync(x => x.SetProperty(p => p.IsArchived, true));

        return Unit.Value;
    }
}