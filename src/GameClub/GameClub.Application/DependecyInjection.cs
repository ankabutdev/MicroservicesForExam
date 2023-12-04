﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GameClub.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
