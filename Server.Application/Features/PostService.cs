using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Interfaces.Persistence;
using Server.Application.Common.Interfaces.Services;
using Server.Domain.Entity.Content;

namespace Server.Application.Features;

public class PostService : IPostService
{
    ILogger<PostService> _logger;
    IPostRepository _postRepository;

    public PostService(ILogger<PostService> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }

    public async Task<List<PostDto>> GetAllPostsAsync()
    {
        _logger.LogInformation("Get All Post Here");
        var posts = await _postRepository.GetAllAsync();

        var postsDto = posts.Select(PostDto.FromEntity).ToList();

        return postsDto!;
    }

    public async Task<PostDto> GetById(Guid slug)
    {
        _logger.LogInformation("Get post here");
        var post = await _postRepository.GetByIdAsync(slug);

        var postsDto = PostDto.FromEntity(post);

        return postsDto!;
    }
}
