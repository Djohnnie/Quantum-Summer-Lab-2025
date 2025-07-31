using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public string Message { get; set; }
}

public class VerifyChallengeSolutionCommandHandler : IRequestHandler<VerifyChallengeSolutionCommand, VerifyChallengeSolutionResponse>
{
    private readonly QuantumSummerLabDbContext _dbContext;

    public VerifyChallengeSolutionCommandHandler(
        QuantumSummerLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VerifyChallengeSolutionResponse> Handle(VerifyChallengeSolutionCommand request, CancellationToken cancellationToken)
    {
        var challenge = await _dbContext.Challenges.SingleOrDefaultAsync(
            x => x.Name == request.ChallengeName, cancellationToken);
        var team = await _dbContext.Teams.SingleOrDefaultAsync(
            x => x.Name == request.TeamName, cancellationToken);

        _dbContext.Scores.Add(new Score
        {
            Challenge = challenge,
            Team = team,
            IsSuccessful = false,
            ProposedSolution = request.Solution,
            SubmissionTimestamp = request.Timestamp
        });
    }
}