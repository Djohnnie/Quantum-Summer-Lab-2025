using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Application.Scores.Queries;

public class GetYourSubmissionsQuery : IRequest<GetYourSubmissionsResponse>
{
    public string ChallengeName { get; set; }
    public string TeamName { get; set; }
}

public class GetYourSubmissionsResponse
{
    public List<YourSubmission> YourSubmissions { get; set; } = new List<YourSubmission>();
}

public class YourSubmission
{
    public bool IsSuccessful { get; set; }
    public string ProposedSolution { get; set; }
    public DateTime SubmissionTimestamp { get; set; }
}

public class GetYourSubmissionsQueryHandler : IRequestHandler<GetYourSubmissionsQuery, GetYourSubmissionsResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetYourSubmissionsQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetYourSubmissionsResponse> Handle(GetYourSubmissionsQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
        var submissions = await dbContext.Scores
            .Where(x => x.Challenge.Name == request.ChallengeName && x.Team.Name == request.TeamName)
            .OrderByDescending(x => x.SubmissionTimestamp)
            .Select(x => new YourSubmission
            {
                IsSuccessful = x.IsSuccessful,
                ProposedSolution = x.ProposedSolution,
                SubmissionTimestamp = x.SubmissionTimestamp
            })
            .ToListAsync(cancellationToken);

        foreach (var submission in submissions)
        {
            submission.ProposedSolution = $"```js{Environment.NewLine}{submission.ProposedSolution.FromBase64String()}{Environment.NewLine}```";
        }

        return new GetYourSubmissionsResponse
        {
            YourSubmissions = submissions
        };
    }
}