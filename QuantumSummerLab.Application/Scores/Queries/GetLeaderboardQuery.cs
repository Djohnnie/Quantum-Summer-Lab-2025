using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public long Timestamp { get; set; }
    public int ProcessingTime { get; set; }
}

public class GetLeaderboardQueryHandler : IRequestHandler<GetLeaderboardQuery, GetLeaderboardResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetLeaderboardQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetLeaderboardResponse> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var teams = await dbContext.Teams.Where(x => !x.IsArchived).ToListAsync(cancellationToken);

        var scores = await dbContext.Scores
            .Where(x => !x.Team.IsArchived)
            .Include(s => s.Team)
            .GroupBy(s => s.Team)
            .Select(g => new
            {
                TeamName = g.Key.Name,
                Scores = g.Select(s => new
                {
                    s.IsSuccessful,
                    Score = s.IsSuccessful ? s.Challenge.Level * 100 : -1,
                    ChallengeName = s.Challenge.Name,
                    Timestamp = s.SubmissionTimestamp
                })
            })
            .ToListAsync(cancellationToken);

        var chats = await dbContext.Chats
            .Include(s => s.Team)
            .GroupBy(c => c.Team.Name)
            .Select(g => new
            {
                TeamName = g.Key,
                ProcessingTime = g.Sum(c => c.ProcessingTime),
            })
            .ToListAsync(cancellationToken);

        var entries = new List<LeaderboardEntry>();

        foreach (var team in teams)
        {
            var scoresForTeam = scores.SingleOrDefault(x => x.TeamName == team.Name);
            if (scoresForTeam != null)
            {
                entries.Add(new LeaderboardEntry
                {
                    TeamName = scoresForTeam.TeamName,
                    TotalPoints = 100 + scoresForTeam.Scores.Sum(x => x.Score),
                    ChallengesTried = scoresForTeam.Scores.Count(),
                    ChallengesCompleted = scoresForTeam.Scores.GroupBy(x => x.ChallengeName).Count(x => x.Any(a => a.IsSuccessful)),
                    Timestamp = scoresForTeam.Scores.Any(x => x.IsSuccessful)
                        ? scoresForTeam.Scores
                            .Where(x => x.IsSuccessful)
                            .GroupBy(x => x.ChallengeName)
                            .Select(g => g.MinBy(s => s.Timestamp)?.Timestamp.Ticks ?? 0)
                            .Sum()
                        : 0,
                    ProcessingTime = chats.SingleOrDefault(x => x.TeamName == team.Name)?.ProcessingTime ?? 0,
                });
            }
            else
            {
                entries.Add(new LeaderboardEntry
                {
                    TeamName = team.Name,
                    TotalPoints = 0,
                    ChallengesTried = 0,
                    ChallengesCompleted = 0,
                    Timestamp = 0,
                    ProcessingTime = 0
                });
            }
        }

        entries = entries
            .OrderByDescending(e => e.TotalPoints)
            .ThenBy(x => x.Timestamp)
            .ThenBy(x => x.TeamName)
            .ToList();

        for (var i = 0; i < entries.Count; i++)
        {
            entries[i].Position = i + 1;
        }

        return new GetLeaderboardResponse
        {
            Entries = entries
        };
    }
}