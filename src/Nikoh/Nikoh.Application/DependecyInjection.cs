using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nikoh.Application.Mappers;
using System.Reflection;

namespace Nikoh.Application;

public static class DepandecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        return services;
    }
}