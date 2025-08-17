using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Teams.Queries;

public class GetTeamByIdQuery : IRequest<GetTeamByIdResponse>
{
    public Guid TeamId { get; set; }
}

public class GetTeamByIdResponse
{
    public string TeamName { get; set; }
}

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, GetTeamByIdResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetTeamByIdQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetTeamByIdResponse> Handle(GetTeamByIdQuery query, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var team = await dbContext.Teams
            .SingleOrDefaultAsync(x => x.Id == query.TeamId, cancellationToken);

        return new GetTeamByIdResponse
        {
            TeamName = team?.Name ?? string.Empty
        };
    }
}