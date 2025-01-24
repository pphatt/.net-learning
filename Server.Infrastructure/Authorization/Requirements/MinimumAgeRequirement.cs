using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace Server.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int _MinimumAge { get; set; }

    public MinimumAgeRequirement(int MinimumAge)
    {
        _MinimumAge = MinimumAge;
    }
}
