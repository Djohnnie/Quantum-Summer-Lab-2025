using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Application.Scores.Commands;
using QuantumSummerLab.Data;
using System.Text.Json;

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
    public DateTime SubmissionTimestamp { get; set; }
    public string ProposedSolution { get; set; }
    public List<SubmissionFeedback> Feedback { get; set; }
}

public class SubmissionFeedback
{
    public bool Valid { get; set; }
    public string Message { get; set; }
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
        var scores = await dbContext.Scores
            .Where(x => x.Challenge.Name == request.ChallengeName && x.Team.Name == request.TeamName)
            .OrderByDescending(x => x.SubmissionTimestamp)
            .Select(x => new
            {
                x.IsSuccessful,
                x.ProposedSolution,
                x.SubmissionTimestamp,
                x.Feedback
            })
            .ToListAsync(cancellationToken);

        var submissions = new List<YourSubmission>();

        foreach (var score in scores)
        {
            var feedback = string.IsNullOrEmpty(score.Feedback) ? new QSharpFeedback() : JsonSerializer.Deserialize<QSharpFeedback>(score.Feedback);

            submissions.Add(new YourSubmission
            {
                IsSuccessful = score.IsSuccessful,
                ProposedSolution = $"```js{Environment.NewLine}{score.ProposedSolution.FromBase64String()}{Environment.NewLine}```",
                SubmissionTimestamp = score.SubmissionTimestamp,
                Feedback = feedback.Messages.Select(x => new SubmissionFeedback
                {
                    Valid = x.Valid,
                    Message = x.Message
                }).ToList()
            });
        }

        return new GetYourSubmissionsResponse
        {
            YourSubmissions = submissions
        };
    }
}