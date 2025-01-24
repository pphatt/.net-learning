using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Server.Domain.Entity.Identity;
using Server.Infrastructure.Common.Constants;
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

        if (user.FirstName is not null)
        {
            id.AddClaim(new Claim(AppClaimsTypes.FirstName, user.FirstName));
        }

        if (user.LastName is not null)
        {
            id.AddClaim(new Claim(AppClaimsTypes.LastName, user.LastName));
        }

        if (user.Nationality is not null)
        {
            id.AddClaim(new Claim(AppClaimsTypes.Nationality, user.Nationality));
        }

        if (user.Dob is not null)
        {
            id.AddClaim(new Claim(AppClaimsTypes.Dob, user.Dob.Value.ToString("dd-MM-yyyy")));
        }

        return new ClaimsPrincipal(id);
    }
}
