using System.Security.Cryptography;
using System.Text;

namespace QuantumSummerLab.Application.Helpers;

public class PasswordHash
{
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Hash { get; set; }
}

public interface IPasswordHashHelper
{
    PasswordHash CalculateHash(PasswordHash password);
}

public class PasswordHashHelper : IPasswordHashHelper
{
    public PasswordHash CalculateHash(PasswordHash password)
    {
        if (string.IsNullOrEmpty(password.Salt))
        {
            var saltData = new byte[16];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltData);

            password.Salt = Convert.ToBase64String(saltData);
        }

        var saltedPassword = $"{password.Salt}{password.Password}";

        var hashed = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));

        password.Hash = Convert.ToBase64String(hashed);

        return password;
    }
}