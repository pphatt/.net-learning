using FluentValidation;

namespace Server.Application.Features.IdentityApp.Commands.AssignUserRole;

public class AssignUserRoleCommandValidator : AbstractValidator<AssignUserRoleCommand>
{
    public AssignUserRoleCommandValidator()
    {
    }
}
