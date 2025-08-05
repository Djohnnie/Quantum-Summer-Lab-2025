
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;
using QuantumSummerLab.Tools;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddApplicationServices(configuration);
serviceCollection.AddSingleton<IConfiguration>(configuration);
using var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("Quantum Summer Lab 2025 console tool");
Console.WriteLine("------------------------------------");
Console.WriteLine();
Console.WriteLine("1. Clear database");
Console.WriteLine("2. Add challenges");
Console.WriteLine("3. Exit");
Console.WriteLine();

var key = Console.ReadKey(true);

switch (key.Key)
{
    case ConsoleKey.D1:
    case ConsoleKey.NumPad1:
        await ClearDatabase(serviceProvider);
        break;
    case ConsoleKey.D2:
    case ConsoleKey.NumPad2:
        await AddChallenges(serviceProvider);
        break;
    case ConsoleKey.D3:
    case ConsoleKey.NumPad3:
        return;
    default:
        Console.WriteLine("Invalid option. Exiting...");
        return;
}

static async Task ClearDatabase(IServiceProvider serviceProvider)
{
    Console.WriteLine("Clearing database...");

    var dbContext = serviceProvider.GetService<QuantumSummerLabDbContext>();
    await dbContext.Scores.ExecuteDeleteAsync();
    await dbContext.Challenges.ExecuteDeleteAsync();
    await dbContext.Teams.ExecuteDeleteAsync();

    Console.WriteLine("Done clearing database. Exiting...");
}

static async Task AddChallenges(IServiceProvider serviceProvider)
{
    Console.WriteLine("Adding challenges...");

    var dbContext = serviceProvider.GetService<QuantumSummerLabDbContext>();

    await ProcessChallenge(dbContext, Challenges.CHALLENGE_0);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_A1);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_A2);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_A3);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_B1);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_B2);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_B3);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_C1);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_C2);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_C3);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_D1);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_D2);
    await ProcessChallenge(dbContext, Challenges.CHALLENGE_D3);

    Console.WriteLine("Done adding challenges. Exiting...");
}

static async Task ProcessChallenge(QuantumSummerLabDbContext dbContext, Challenge challenge)
{
    if (await dbContext.Challenges.AnyAsync(x => x.Name == challenge.Name))
    {
        await dbContext.Challenges.Where(x => x.Name == challenge.Name).ExecuteUpdateAsync(setters =>
            setters.SetProperty(p => p.Title, challenge.Title)
                   .SetProperty(p => p.Description, challenge.Description)
                   .SetProperty(p => p.SolutionTemplate, challenge.SolutionTemplate)
                   .SetProperty(p => p.ExampleDescription, challenge.ExampleDescription)
                   .SetProperty(p => p.ExampleCode, challenge.ExampleCode)
                   .SetProperty(p => p.VerificationTemplate, challenge.VerificationTemplate)
                   .SetProperty(p => p.ExpectedOutput, challenge.ExpectedOutput)
                   .SetProperty(p => p.Level, challenge.Level)
        );
    }
    else
    {
        dbContext.Challenges.Add(challenge);
        await dbContext.SaveChangesAsync();
    }
}