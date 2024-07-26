using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SchoolDb")));
        
        // Add other infrastructure services here
        services.AddScoped<IStudentRepo, StudentRepo>();
        return services;
    }
}