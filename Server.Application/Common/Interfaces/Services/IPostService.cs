using Server.Domain.Entity.Content;

namespace Server.Application.Common.Interfaces.Services;

public interface IPostService
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> GetById(Guid slug);
}
