using FluentValidation;

namespace Server.Application.Features.CommentApp.Commands.UpdateComment;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        //RuleFor();
    }
}
