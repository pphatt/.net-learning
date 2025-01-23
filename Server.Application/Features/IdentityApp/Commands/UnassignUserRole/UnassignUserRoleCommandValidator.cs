using FluentValidation;

namespace Server.Application.Features.IdentityApp.Commands.UnassignUserRole;

public class UnassignUserRoleCommandValidator : AbstractValidator<UnassignUserRoleCommand>
{
    public UnassignUserRoleCommandValidator()
    {
    }
}
