using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Server.Domain.Entity.Identity;
using Server.Domain.Exceptions;

namespace Server.Application.Features.IdentityApp.Commands.UnassignUserRole;

public class UnassignUserRoleCommandHandler : IRequestHandler<UnassignUserRoleCommand>
{
    ILogger<UnassignUserRoleCommandHandler> _logger;
    UserManager<AppUsers> _userManager;
    RoleManager<IdentityRole<Guid>> _roleManager;

    public UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger, UserManager<AppUsers> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
        {
            throw new NotFoundException(nameof(AppUsers), request.UserId);
        }

        var role = await _roleManager.FindByIdAsync(request.RoleId);

        if (role is null)
        {
            throw new NotFoundException(nameof(IdentityRole), request.RoleId);
        }

        await _userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
