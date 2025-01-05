using Server.Application.Common.Dtos.Posts;
using Server.Application.Features.PostApp.Commands.UpdatePost;
using Server.Domain.Entity.Content;

namespace Server.Application.Common.Interfaces.Persistence;

public interface IPostRepository
{
    Task CompleteAsync();
    Task<List<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(Guid slug);
    Task<Guid> CreatePost(Post entity); 
    Task<bool> DeletePost(Guid id);
}
