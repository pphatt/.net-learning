using Server.Domain.Entity.Content;

namespace Server.Domain.Features;

public interface IPostService
{
    Task<List<Post>> GetAllPostsAsync();
}
