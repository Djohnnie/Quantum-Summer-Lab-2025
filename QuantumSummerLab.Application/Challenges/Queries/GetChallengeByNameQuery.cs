using MediatR;
using Microsoft.EntityFrameworkCore;
using QuantumSummerLab.Data;
using System.Text;

namespace QuantumSummerLab.Application.Challenges.Queries;

public class GetChallengeByNameQuery : IRequest<GetChallengeByNameResponse>
{
    public string ChallengeName { get; set; }
}

public class GetChallengeByNameResponse
{
    public bool IsAvailable { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public string SolutionTemplate { get; set; }
    public string ExpectedOutput { get; set; }
}

public class GetChallengeByNameQueryHandler : IRequestHandler<GetChallengeByNameQuery, GetChallengeByNameResponse>
{
    private readonly QuantumSummerLabDbContext _dbContext;

    public GetChallengeByNameQueryHandler(
        QuantumSummerLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetChallengeByNameResponse> Handle(GetChallengeByNameQuery request, CancellationToken cancellationToken)
    {
        var challenge = await _dbContext.Challenges
            .FirstOrDefaultAsync(c => c.Name == request.ChallengeName, cancellationToken);

        if (challenge is null)
        {
            return new GetChallengeByNameResponse { IsAvailable = false };
        }

        return new GetChallengeByNameResponse
        {
            IsAvailable = true,
            Name = challenge.Name,
            Title = challenge.Title,
            Description = challenge.Description,
            Level = challenge.Level,
            SolutionTemplate = Encoding.UTF8.GetString(Convert.FromBase64String(challenge.SolutionTemplate)),
            ExpectedOutput = challenge.ExpectedOutput
        };
    }
}