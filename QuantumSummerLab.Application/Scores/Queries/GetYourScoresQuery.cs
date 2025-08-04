using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Scores.Queries;

public class GetYourScoresQuery : IRequest<GetYourScoresResponse>
{
    public string TeamName { get; set; }
}

public class GetYourScoresResponse
{
    public List<ChallengeScore> Scores { get; set; } = new List<ChallengeScore>();
}

public class ChallengeScore
{
    public string ChallengeName { get; set; }
    public bool IsSuccess { get; set; }
    public int TotalAttempts { get; set; }
    public int Score { get; set; }
}

public class GetYourScoresQueryHandler : IRequestHandler<GetYourScoresQuery, GetYourScoresResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetYourScoresQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetYourScoresResponse> Handle(GetYourScoresQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
        var scores = await dbContext.Scores
            .Where(x => x.Team.Name == request.TeamName)
            .GroupBy(x => x.Challenge.Name)
            .Select(x => new
            {
                ChallengeName = x.Key,
                IsSuccess = x.Any(s => s.IsSuccessful),
                TotalAttempts = x.Count(),
                Score = x.Select(x => x.Challenge.Level * (x.IsSuccessful ? 1 : 0)),
            })
            .ToListAsync(cancellationToken);

        return new GetYourScoresResponse
        {
            Scores = scores.Select(x => new ChallengeScore
            {
                ChallengeName = x.ChallengeName,
                IsSuccess = x.IsSuccess,
                TotalAttempts = x.TotalAttempts,
                Score = x.Score.Sum()
            }).ToList()
        };
    }
}