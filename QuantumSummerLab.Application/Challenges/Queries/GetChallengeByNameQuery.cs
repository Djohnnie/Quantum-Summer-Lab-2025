using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Extensions;
using QuantumSummerLab.Data;

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
    public string SolutionTemplate { get; set; }
    public string ExampleDescription { get; set; }
    public string ExampleCode { get; set; }
}

public class GetChallengeByNameQueryHandler : IRequestHandler<GetChallengeByNameQuery, GetChallengeByNameResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GetChallengeByNameQueryHandler(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<GetChallengeByNameResponse> Handle(GetChallengeByNameQuery request, CancellationToken cancellationToken)
    {
        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
        var challenge = await dbContext.Challenges
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
            SolutionTemplate = challenge.SolutionTemplate.FromBase64String(),
            ExampleDescription = challenge.ExampleDescription,
            ExampleCode = challenge.ExampleCode.FromBase64String()
        };
    }
}