using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace QuantumSummerLab.Application.Scores.Commands;

public class VerifyChallengeSolutionCommand : IRequest<VerifyChallengeSolutionResponse>
{
    public string ChallengeName { get; set; }
    public string TeamName { get; set; }
    public string Solution { get; set; }
    public DateTime Timestamp { get; set; }
}

public class VerifyChallengeSolutionResponse
{
    public bool IsValid { get; set; }
    public string FeedbackMessage { get; set; }
    public List<VerificationFeedback> Feedback { get; set; }
}

public class VerificationFeedback
{
    public bool Valid { get; set; }
    public string Message { get; set; }
}

public class QSharpRequest
{
    public string VerificationTemplate { get; set; }
    public string Solution { get; set; }
    public string ExpectedOutput { get; set; }
    public string ExpectedStates { get; set; }
}

public class QSharpFeedback
{
    public bool IsValid { get; set; }
    public List<QSharpFeedbackMessage> Messages { get; set; } = new List<QSharpFeedbackMessage>();
}

public class QSharpFeedbackMessage
{
    public bool Valid { get; set; }
    public string Message { get; set; }
}

public class VerifyChallengeSolutionCommandHandler : IRequestHandler<VerifyChallengeSolutionCommand, VerifyChallengeSolutionResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;

    public VerifyChallengeSolutionCommandHandler(
        IServiceScopeFactory scopeFactory,
        IConfiguration configuration)
    {
        _scopeFactory = scopeFactory;
        _configuration = configuration;
    }

    public async Task<VerifyChallengeSolutionResponse> Handle(VerifyChallengeSolutionCommand request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

        var challenge = await dbContext.Challenges.SingleOrDefaultAsync(
                x => x.Name == request.ChallengeName, cancellationToken);
        var team = await dbContext.Teams.SingleOrDefaultAsync(
            x => x.Name == request.TeamName, cancellationToken);

        var verificationTemplate = challenge.VerificationTemplate.FromBase64String();
        var solution = verificationTemplate.Replace("<<SOLVE>>", request.Solution);

        var requestData = new QSharpRequest
        {
            VerificationTemplate = verificationTemplate.ToBase64String(),
            Solution = request.Solution.ToBase64String(),
            ExpectedOutput = challenge.ExpectedOutput.ToBase64String(),
            ExpectedStates = challenge.ExpectedStates
        };

        var qsharpHelperBaseAdderess = _configuration.GetValue<string>("QSHARP_HELPER_BASE_ADDRESS");

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(qsharpHelperBaseAdderess);
        var httpResponse = await httpClient.PostAsJsonAsync("api/QSharpVerificationFunction", requestData, cancellationToken);
        var feedback = await httpResponse.Content.ReadFromJsonAsync<QSharpFeedback>(cancellationToken);

        dbContext.Scores.Add(new Score
        {
            Challenge = challenge,
            Team = team,
            IsSuccessful = feedback.IsValid,
            Feedback = JsonSerializer.Serialize(feedback),
            ProposedSolution = request.Solution.ToBase64String(),
            SubmissionTimestamp = request.Timestamp
        });
        await dbContext.SaveChangesAsync(cancellationToken);

        return new VerifyChallengeSolutionResponse
        {
            IsValid = feedback.IsValid,
            FeedbackMessage = $"Your submitted solution {(feedback.IsValid ? "is" : "is not")} correct.",
            Feedback = feedback.Messages.Select(m => new VerificationFeedback
            {
                Valid = m.Valid,
                Message = m.Message
            }).ToList()
        };
    }
}