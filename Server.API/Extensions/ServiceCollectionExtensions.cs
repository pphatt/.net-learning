using Microsoft.EntityFrameworkCore;
using Server.Infrastructure;
using System.Reflection;

namespace Server.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // default services.
        services.AddControllers();

        // auto-mapper service.
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
