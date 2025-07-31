using MediatR;
using Microsoft.EntityFrameworkCore;
using QsharpBridge;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;
using System.Text;

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
    public string Message { get; set; }
}

public class VerifyChallengeSolutionCommandHandler : IRequestHandler<VerifyChallengeSolutionCommand, VerifyChallengeSolutionResponse>
{
    private readonly QuantumSummerLabDbContext _dbContext;
    private readonly IQSharpHelper _qSharpHelper;

    public VerifyChallengeSolutionCommandHandler(
        QuantumSummerLabDbContext dbContext,
        IQSharpHelper qSharpHelper)
    {
        _dbContext = dbContext;
        _qSharpHelper = qSharpHelper;
    }

    public async Task<VerifyChallengeSolutionResponse> Handle(VerifyChallengeSolutionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var challenge = await _dbContext.Challenges.SingleOrDefaultAsync(
                x => x.Name == request.ChallengeName, cancellationToken);
            var team = await _dbContext.Teams.SingleOrDefaultAsync(
                x => x.Name == request.TeamName, cancellationToken);

            var verificationTemplate = Encoding.UTF8.GetString(Convert.FromBase64String(challenge.VerificationTemplate));
            var solution = verificationTemplate.Replace("<<SOLVE>>", request.Solution);

            var isValid = _qSharpHelper.Verify(verificationTemplate, request.Solution, challenge.ExpectedOutput);

            _dbContext.Scores.Add(new Score
            {
                Challenge = challenge,
                Team = team,
                IsSuccessful = isValid,
                ProposedSolution = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Solution)),
                SubmissionTimestamp = request.Timestamp
            });
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new VerifyChallengeSolutionResponse
            {
                IsValid = isValid,
                Message = $"Solution {(isValid ? "is" : "is not")} valid."
            };
        }
        catch (QsException ex)
        {
            return new VerifyChallengeSolutionResponse
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}