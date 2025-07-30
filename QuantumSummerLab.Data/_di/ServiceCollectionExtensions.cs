using Microsoft.Extensions.DependencyInjection;

namespace QuantumSummerLab.Data.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddDbContext<QuantumSummerLabDbContext>();

        return services;
    }
}