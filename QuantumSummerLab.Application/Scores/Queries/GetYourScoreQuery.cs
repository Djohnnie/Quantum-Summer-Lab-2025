using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    private readonly IServiceScopeFactory _scopeFactory;

    public GetYourScoreQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetYourScoreResponse> Handle(GetYourScoreQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
        var scores = await dbContext.Scores
            .Where(x => x.Challenge.Name == request.ChallengeName && x.Team.Name == request.TeamName)
            .Select(x => new
            {
                x.IsSuccessful,
                Score = x.IsSuccessful ? x.Challenge.Level * 100 : -1,
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