using MediatR;

namespace Server.Application.Features.IdentityApp.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string UserId { get; set; }

    public string RoleId { get; set; }
}
