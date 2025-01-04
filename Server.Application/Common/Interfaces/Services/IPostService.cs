using Server.Application.Common.Dtos.Posts;
using Server.Domain.Entity.Content;

namespace Server.Application.Common.Interfaces.Services;

public interface IPostService
{
    Task<List<PostDto>> GetAllPostsAsync();
    Task<PostDto> GetById(Guid slug);
    Task CreatePost(CreatePostDto dto);
}
