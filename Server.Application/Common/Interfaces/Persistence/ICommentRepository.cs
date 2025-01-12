using Server.Domain.Entity.Content;

namespace Server.Application.Common.Interfaces.Persistence;

public interface ICommentRepository
{
    Task CompleteAsync();
    Task<List<PostComments>> GetAllPostComments(Guid PostId);
    Task<PostComments?> GetByIdAsync(Guid Id);
    Task<Guid> CreateComment(PostComments postComments);
}
