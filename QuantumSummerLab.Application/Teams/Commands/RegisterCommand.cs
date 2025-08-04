using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public string Token { get; set; }
    public string ErrorMessage { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IPasswordHashHelper _passwordHashHelper;
    private readonly QuantumSummerLabDbContext _dbContext;

    public RegisterCommandHandler(
        IPasswordHashHelper passwordHashHelper,
        QuantumSummerLabDbContext dbContext)
    {
        _passwordHashHelper = passwordHashHelper;
        _dbContext = dbContext;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = _passwordHashHelper.CalculateHash(new PasswordHash
            {
                Password = request.Password
            });

            _dbContext.Teams.Add(new Team
            {
                Name = request.TeamName,
                PasswordSalt = passwordHash.Salt,
                PasswordHash = passwordHash.Hash
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new RegisterResponse
            {
                Success = true,
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