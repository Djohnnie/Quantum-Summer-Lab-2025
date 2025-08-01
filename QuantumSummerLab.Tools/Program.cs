
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Data;
using QuantumSummerLab.Data.Model;


Console.WriteLine("Quantum Summer Lab 2025 console tool");
Console.WriteLine("------------------------------------");
Console.WriteLine();

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddApplicationServices(configuration);
serviceCollection.AddSingleton<IConfiguration>(configuration);
using var serviceProvider = serviceCollection.BuildServiceProvider();

var dbContext = serviceProvider.GetService<QuantumSummerLabDbContext>();
if (!await dbContext.Challenges.AnyAsync(x => x.Name == "0"))
{
    dbContext.Challenges.Add(new Challenge
    {
        Name = "0",
        Title = "Example Challenge",
        Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
        ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
        VerificationTemplate = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    });
}

if (!await dbContext.Challenges.AnyAsync(x => x.Name == "A2"))
{
    dbContext.Challenges.Add(new Challenge
    {
        Name = "A2",
        Title = "Example Challenge",
        Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
        ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
        VerificationTemplate = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    });
}

if (!await dbContext.Challenges.AnyAsync(x => x.Name == "A3"))
{
    dbContext.Challenges.Add(new Challenge
    {
        Name = "A3",
        Title = "Example Challenge",
        Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
        ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
        VerificationTemplate = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    });
}

await dbContext.SaveChangesAsync();