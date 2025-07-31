using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumSummerLab.Application.Helpers;
using QuantumSummerLab.Data.DependencyInjection;
using System.Reflection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var licenseKey = configuration.GetValue<string>("MEDIATR_LICENSEKEY");

        services.AddMediatR(c =>
        {
            c.LicenseKey = licenseKey;
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();
        services.AddScoped<IQSharpHelper, QSharpHelper>();
        services.AddDataServices();

        return services;
    }
}