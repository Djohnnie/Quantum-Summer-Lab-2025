using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Teams.Queries;

public class GetTeamsQuery : IRequest<GetTeamsResponse>
{
}

public class GetTeamsResponse
{
    public List<TeamDto> Teams { get; set; } = new List<TeamDto>();
}

public class TeamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsArchived { get; set; }
}

public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, GetTeamsResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetTeamsQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetTeamsResponse> Handle(GetTeamsQuery query, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var teams = await dbContext.Teams
            .OrderByDescending(t => t.IsArchived)
            .ThenBy(t => t.Name)
            .Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                IsArchived = x.IsArchived
            })
            .ToListAsync(cancellationToken);

        return new GetTeamsResponse
        {
            Teams = teams
        };
    }
}