using Microsoft.Extensions.DependencyInjection;
using Server.Application.Features;
using Server.Domain.Features;

namespace Server.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();

        return services;
    }
}
