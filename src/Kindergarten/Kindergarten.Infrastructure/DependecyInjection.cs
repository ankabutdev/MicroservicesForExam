using Kindergarten.Application.Abstractions;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kindergarten.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dockerConnection = configuration.GetConnectionString("DockerConnection");
        var defaultConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
        {
            options.UseNpgsql(defaultConnection);
        });

        return services;
    }
}
