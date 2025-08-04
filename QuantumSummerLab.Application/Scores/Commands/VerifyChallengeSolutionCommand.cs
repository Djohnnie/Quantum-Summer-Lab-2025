using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QsharpBridge;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;

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

            var isValid = _qSharpHelper.Verify(verificationTemplate, request.Solution, challenge.ExpectedOutput);

            dbContext.Scores.Add(new Score
            {
                Challenge = challenge,
                Team = team,
                IsSuccessful = isValid,
                ProposedSolution = request.Solution.ToBase64String(),
                SubmissionTimestamp = request.Timestamp
            });
            await dbContext.SaveChangesAsync(cancellationToken);

            return new VerifyChallengeSolutionResponse
            {
                IsValid = isValid,
                FeedbackMessage = $"Your submitted solution {(isValid ? "is" : "is not")} correct."
            };
        }
        catch (QsException ex)
        {
            return new VerifyChallengeSolutionResponse
            {
                IsValid = false,
                FeedbackMessage = "There has been an error while compiling or running your Q# code!"
            };
        }
    }
}