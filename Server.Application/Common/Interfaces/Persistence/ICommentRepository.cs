using Server.Application.Features.CommentApp.Commands.UpdateComment;
using Server.Domain.Entity.Content;

namespace Server.Application.Common.Interfaces.Persistence;

public interface ICommentRepository
{
    Task CompleteAsync();
    Task<PostComments> GetByIdAsync(Guid Id);
    Task<Guid> CreateComment(PostComments postComments);
}
