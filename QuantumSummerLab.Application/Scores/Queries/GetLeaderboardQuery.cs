using MediatR;
using Microsoft.EntityFrameworkCore;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Scores.Queries;

public class GetLeaderboardQuery : IRequest<GetLeaderboardResponse>
{

}

public class GetLeaderboardResponse
{
    public List<LeaderboardEntry> Entries { get; set; } = new List<LeaderboardEntry>();
}

public class LeaderboardEntry
{
    public int Position { get; set; }
    public string TeamName { get; set; }
    public int TotalPoints { get; set; }
    public int ChallengesTried { get; set; }
    public int ChallengesCompleted { get; set; }
    public int TotalChallenges { get; set; }
}

public class GetLeaderboardQueryHandler : IRequestHandler<GetLeaderboardQuery, GetLeaderboardResponse>
{
    private readonly QuantumSummerLabDbContext _dbContext;

    public GetLeaderboardQueryHandler(
        QuantumSummerLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetLeaderboardResponse> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
    {
        var scores = await _dbContext.Scores
            .Include(s => s.Team)
            .GroupBy(s => s.Team)
            .Select(g => new LeaderboardEntry
            {
                TeamName = g.Key.Name,
                TotalPoints = g.Sum(s => s.IsSuccessful ? 1 : 0),
                ChallengesTried = g.Count(),
                ChallengesCompleted = g.Count(s => s.IsSuccessful),
                TotalChallenges = _dbContext.Challenges.Count()
            })
            .OrderByDescending(e => e.TotalPoints)
            .ToListAsync(cancellationToken);

        return new GetLeaderboardResponse
        {
            Entries = scores.Select((e, index) =>
            {
                e.Position = index + 1;
                return e;
            }).ToList()
        };
    }
}