using Application.Services;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        // Register application services here
        services.AddScoped<IStudentService, StudentService>();
        services.AddInfrastructure(configuration);
        return services;
    }
}