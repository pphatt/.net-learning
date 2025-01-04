using FluentValidation;
using Server.Application.Common.Dtos.Posts;

namespace Server.Application.Common.Validators.Post;

public class CreatePostValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostValidator()
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
