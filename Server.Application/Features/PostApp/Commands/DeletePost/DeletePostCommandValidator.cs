using FluentValidation;

namespace Server.Application.Features.PostApp.Commands.DeletePost;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(dto => dto.Id)
            .NotNull()
            .NotEmpty();
    }
}
