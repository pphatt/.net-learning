using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Services;

namespace Server.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    ILogger<MinimumAgeRequirementHandler> _logger;
    IUserService _userService;

    public MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = _userService.CurrentUser();

        if (currentUser is null)
        {
            _logger.LogInformation("Authorization Failed.");
            context.Fail();
            return Task.CompletedTask;
        }

        _logger.LogInformation("User: {Email}, date of birth: {Dob} - Handling MinimumAgeRequirement", currentUser._Email, currentUser._Dob);

        if (currentUser._Dob.Value.AddYears(requirement._MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            _logger.LogInformation("Authorization Succeed.");
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
