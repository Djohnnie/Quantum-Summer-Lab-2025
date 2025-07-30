using MediatR;
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
}