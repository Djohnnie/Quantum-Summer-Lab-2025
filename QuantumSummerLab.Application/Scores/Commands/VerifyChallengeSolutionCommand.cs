using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QsharpBridge;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Application.Scores.Queries;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;
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

public class VerifyChallengeSolutionCommandHandler : IRequestHandler<VerifyChallengeSolutionCommand, VerifyChallengeSolutionResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IQSharpHelper _qSharpHelper;

    public VerifyChallengeSolutionCommandHandler(
        IServiceScopeFactory scopeFactory,
        IQSharpHelper qSharpHelper)
    {
        _scopeFactory = scopeFactory;
        _qSharpHelper = qSharpHelper;
    }

    public async Task<VerifyChallengeSolutionResponse> Handle(VerifyChallengeSolutionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();

            var challenge = await dbContext.Challenges.SingleOrDefaultAsync(
                x => x.Name == request.ChallengeName, cancellationToken);
            var team = await dbContext.Teams.SingleOrDefaultAsync(
                x => x.Name == request.TeamName, cancellationToken);

            var verificationTemplate = challenge.VerificationTemplate.FromBase64String();
            var solution = verificationTemplate.Replace("<<SOLVE>>", request.Solution);

            var feedback = _qSharpHelper.Verify(verificationTemplate, request.Solution, challenge.ExpectedOutput);

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
        catch (QsException ex)
        {
            return new VerifyChallengeSolutionResponse
            {
                IsValid = false,
                FeedbackMessage = ex.Message switch
                {
                    string a when a.Contains("error: Compile") => "There has been an error compiling your Q# code!",
                    string b when b.Contains("error: Eval") => "There has been an error running your Q# code!",
                    _ => "There has been an unknown error :("
                }
            };
        }
        catch
        {
            return new VerifyChallengeSolutionResponse
            {
                IsValid = false,
                FeedbackMessage = "There has been an unknown error :("
            };
        }
    }
}