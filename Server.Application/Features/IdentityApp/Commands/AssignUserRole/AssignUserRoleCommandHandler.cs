using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Server.Domain.Entity.Identity;
using Server.Domain.Exceptions;

namespace Server.Application.Features.IdentityApp.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand>
{
    ILogger<AssignUserRoleCommandHandler> _logger;
    UserManager<AppUsers> _userManager { get; set; }
    RoleManager<IdentityRole<Guid>> _roleManager { get; set; }

    public AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger, UserManager<AppUsers> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assigning user role: {@Request}", request);

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

        await _userManager.AddToRoleAsync(user, role.Name!);
    }
}
