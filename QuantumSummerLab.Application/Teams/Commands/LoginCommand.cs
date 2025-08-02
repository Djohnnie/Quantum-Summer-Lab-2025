using MediatR;
using Microsoft.EntityFrameworkCore;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Data;

namespace QuantumSummerLab.Application.Teams.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public string TeamName { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public bool Success { get; set; }
    public AuthenticationToken Token { get; set; }
}

public class AuthenticationToken
{
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IPasswordHashHelper _passwordHashHelper;
    private readonly QuantumSummerLabDbContext _dbContext;

    public LoginCommandHandler(
        IPasswordHashHelper passwordHashHelper,
        QuantumSummerLabDbContext dbContext)
    {
        _passwordHashHelper = passwordHashHelper;
        _dbContext = dbContext;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var existingTeam = await _dbContext.Teams
            .FirstOrDefaultAsync(t => t.Name == request.TeamName, cancellationToken);

        if (existingTeam == null)
        {
            return new LoginResponse
            {
                Success = false
            };
        }

        var passwordHash = _passwordHashHelper.CalculateHash(new PasswordHash
        {
            Password = request.Password,
            Salt = existingTeam.PasswordSalt
        });

        if (passwordHash.Hash != existingTeam.PasswordHash)
        {
            return new LoginResponse
            {
                Success = false
            };
        }

        return new LoginResponse
        {
            Success = true,
            Token = new AuthenticationToken
            {
                TeamId = existingTeam.Id,
                TeamName = existingTeam.Name
            }
        };
    }
}