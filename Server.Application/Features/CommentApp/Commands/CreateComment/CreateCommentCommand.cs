using MediatR;

namespace Server.Application.Features.CommentApp.Commands.CreateComment;

public class CreateCommentCommand : IRequest<bool>
{
    public Guid PostId { get; set; }
    public string UserId { set; get; } = default!;
    public string Content { get; set; } = default!;
}
