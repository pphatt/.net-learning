using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Identity;
using Server.Infrastructure.Persistence;
using Server.Infrastructure.Repositories;

namespace Server.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        // can add seeder as a service here.
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<AppUsers>()
            .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }
}
