using FluentValidation;

namespace Server.Application.Features.CommentApp.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        //RuleFor();
    }
}
