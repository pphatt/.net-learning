using FluentValidation;

namespace Server.Application.Features.PostApp.Commands.UpdatePost;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty()
            .NotNull()
            .Length(5, 100);

        RuleFor(dto => dto.Content)
            .NotEmpty()
            .NotNull()
            .Length(5, 100);
    }
}
