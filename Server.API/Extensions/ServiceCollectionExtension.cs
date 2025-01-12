using Microsoft.OpenApi.Models;
using Server.API.Middlewares;
using System.Reflection;

namespace Server.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // default services.
        services.AddControllers();

        // error handling middleware.
        services.AddScoped<ErrorHandlingMiddleware>();

        // request time logging.
        services.AddScoped<RquestTimeLoggingMiddleware>();

        // auto-mapper service.
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
