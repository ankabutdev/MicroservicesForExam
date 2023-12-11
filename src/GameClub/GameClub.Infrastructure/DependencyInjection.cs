using GameClub.Application.Abstractions;
using GameClub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameClub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dockerConnection = configuration.GetConnectionString("DockerConnection");
        var defaultConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseSqlServer(dockerConnection);
        });

        return services;
    }
}
