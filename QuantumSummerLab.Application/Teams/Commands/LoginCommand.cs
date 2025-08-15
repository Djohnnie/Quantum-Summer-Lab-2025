using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public string ErrorMessage { get; set; }
}

public class AuthenticationToken
{
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IPasswordHashHelper _passwordHashHelper;

    public LoginCommandHandler(
        IServiceScopeFactory scopeFactory,
        IPasswordHashHelper passwordHashHelper)
    {
        _scopeFactory = scopeFactory;
        _passwordHashHelper = passwordHashHelper;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.TeamName) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new LoginResponse
            {
                Success = false,
                ErrorMessage = "Team name and password must be provided!"
            };
        }

        using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
        var existingTeam = await dbContext.Teams
            .FirstOrDefaultAsync(t => t.Name == request.TeamName, cancellationToken);

        if (existingTeam == null)
        {
            return new LoginResponse
            {
                Success = false,
                ErrorMessage = "The team name and password provided are not valid!"
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
                Success = false,
                ErrorMessage = "The team name and password provided are not valid!"
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