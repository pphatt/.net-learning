using FluentValidation;

namespace Server.Application.Features.PostApp.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(dto => dto.Title)
            .NotNull()
            .NotEmpty()
            .Length(5, 100)
            .WithMessage("Content minimum length is 5 characters and maximum is 100 characters");

        RuleFor(dto => dto.Content)
            .NotNull()
            .NotEmpty()
            .Length(5, 256)
            .WithMessage("Content minimum length is 5 characters and maximum is 256 characters");
    }
}
