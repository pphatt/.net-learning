using FluentValidation;

namespace Server.Application.Features.IdentityApp.Commands.UpdateIdentity;

public class UpdateIdentityCommandValidator : AbstractValidator<UpdateIdentityCommand>
{
    public UpdateIdentityCommandValidator()
    {
    }
}
