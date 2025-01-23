using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Server.Domain.Entity.Identity;
using System.Security.Claims;

namespace Server.Infrastructure.Authorization;

public class AppUsersClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUsers, IdentityRole<Guid>>
{
    UserManager<AppUsers> _userManager;
    RoleManager<IdentityRole<Guid>> _roleManager;
    IOptions<IdentityOptions> _options;

    public AppUsersClaimsPrincipalFactory(UserManager<AppUsers> userManager, RoleManager<IdentityRole<Guid>> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _options = options;
    }

    public override async Task<ClaimsPrincipal> CreateAsync(AppUsers user)
    {
        var id = await GenerateClaimsAsync(user);

        if (user.FirstName != null)
        {
            id.AddClaim(new Claim("FirstName", user.FirstName));
        }

        if (user.LastName != null)
        {
            id.AddClaim(new Claim("LastName", user.LastName));
        }

        return new ClaimsPrincipal(id);
    }
}
