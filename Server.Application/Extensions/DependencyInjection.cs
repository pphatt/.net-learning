using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces.Services;
using Server.Application.Features;

namespace Server.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();

        return services;
    }
}
