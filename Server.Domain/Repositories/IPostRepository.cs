using Server.Domain.Entity.Content;

namespace Server.Domain.Repositories;

public interface IPostRepository
{
    Task<List<Post>> GetAllPosts();
}
