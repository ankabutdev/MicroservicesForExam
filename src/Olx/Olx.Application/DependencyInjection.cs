using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olx.Application.Mappers;
using System.Reflection;

namespace Olx.Application;

public static class DepandecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        return services;
    }
}