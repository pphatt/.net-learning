using MediatR;

namespace Server.Application.Features.IdentityApp.Commands.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserId { get; set; }

    public string RoleId { get; set; }
}
