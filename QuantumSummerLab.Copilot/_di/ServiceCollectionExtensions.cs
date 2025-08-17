using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QuantumSummerLab.Copilot.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCopilotServices(this IServiceCollection services)
    {
        services.AddScoped<ICopilotHelper, CopilotHelper>();

        return services;
    }
}