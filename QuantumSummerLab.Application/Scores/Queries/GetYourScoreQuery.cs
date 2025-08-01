using MediatR;
using Microsoft.EntityFrameworkCore;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Scores.Queries;

public class GetYourScoreQuery : IRequest<GetYourScoreResponse>
{
    public string ChallengeName { get; set; }
    public string TeamName { get; set; }
}

public class GetYourScoreResponse
{
    public bool IsSuccess { get; set; }
    public int TotalAttempts { get; set; }
    public int Score { get; set; }
}

public class GetYourScoreQueryHandler : IRequestHandler<GetYourScoreQuery, GetYourScoreResponse>
{
    private readonly QuantumSummerLabDbContext _dbContext;

    public GetYourScoreQueryHandler(
        QuantumSummerLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetYourScoreResponse> Handle(GetYourScoreQuery request, CancellationToken cancellationToken)
    {
        var scores = await _dbContext.Scores
            .Where(x => x.Challenge.Name == request.ChallengeName && x.Team.Name == request.TeamName)
            .Select(x => new
            {
                x.IsSuccessful,
                Score = x.Challenge.Level * (x.IsSuccessful ? 1 : 0),
            })
            .ToListAsync(cancellationToken);

        return new GetYourScoreResponse
        {
            IsSuccess = scores.Any(x => x.IsSuccessful),
            TotalAttempts = scores.Count,
            Score = scores.Sum(x => x.Score)
        };
    }
}