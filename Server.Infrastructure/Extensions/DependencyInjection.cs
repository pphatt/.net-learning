using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces.Persistence;
using Server.Application.Common.Interfaces.Services;
using Server.Domain.Entity.Identity;
using Server.Infrastructure.Authorization;
using Server.Infrastructure.Common.Constants;
using Server.Infrastructure.Persistence;
using Server.Infrastructure.Repositories;
using Server.Infrastructure.Services;

namespace Server.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        // can add seeder as a service here.
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddHttpContextAccessor();

        return services;
    }

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<AppUsers>()
            .AddRoles<IdentityRole<Guid>>()
            .AddClaimsPrincipalFactory<AppUsersClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality, builder => builder.RequireClaim(AppClaimsTypes.Nationality));

        return services;
    }
}
