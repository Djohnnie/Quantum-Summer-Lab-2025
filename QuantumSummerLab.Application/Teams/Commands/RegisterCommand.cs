using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Application.Teams.Commands;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string TeamName { get; set; }
    public string Password { get; set; }
}

public class RegisterResponse
{
    public bool Success { get; set; }
    public AuthenticationToken Token { get; set; }
    public string ErrorMessage { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IPasswordHashHelper _passwordHashHelper;

    public RegisterCommandHandler(
        IServiceScopeFactory scopeFactory,
        IPasswordHashHelper passwordHashHelper)
    {
        _scopeFactory = scopeFactory;
        _passwordHashHelper = passwordHashHelper;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.TeamName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new RegisterResponse
                {
                    Success = false,
                    ErrorMessage = "Team name and password must be provided!"
                };
            }

            using var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<QuantumSummerLabDbContext>();
            var passwordHash = _passwordHashHelper.CalculateHash(new PasswordHash
            {
                Password = request.Password
            });

            var newTeam = new Team
            {
                Name = request.TeamName,
                PasswordSalt = passwordHash.Salt,
                PasswordHash = passwordHash.Hash
            };

            var trackedTeam = dbContext.Teams.Add(newTeam);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RegisterResponse
            {
                Success = true,
                Token = new AuthenticationToken
                {
                    TeamId = newTeam.Id,
                    TeamName = newTeam.Name
                }
            };
        }
        catch (DbUpdateException ex)  
        {
            return new RegisterResponse
            {
                Success = false,
                ErrorMessage = $"We are not able to register a team using the name '{request.TeamName}'"
            };
        }
        catch
        {
            return new RegisterResponse
            {
                Success = false,
                ErrorMessage = "An unknown error has occurred when registering your team :("
            };
        }
    }
}