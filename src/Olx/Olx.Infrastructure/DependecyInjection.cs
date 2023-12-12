﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olx.Application.Abstractions;
using Olx.Infrastructure.Persistence;

namespace Olx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
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

