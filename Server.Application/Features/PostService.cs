using AutoMapper;
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
    IMapper _mapper;

    public PostService(ILogger<PostService> logger, IPostRepository postRepository, IMapper mapper)
    {
        _logger = logger;
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> GetAllPostsAsync()
    {
        _logger.LogInformation("Get All Post Here");
        var posts = await _postRepository.GetAllAsync();

        var postsDto = _mapper.Map<List<PostDto>>(posts);

        return postsDto!;
    }

    public async Task<PostDto> GetById(Guid slug)
    {
        _logger.LogInformation("Get post here");
        var post = await _postRepository.GetByIdAsync(slug);

        var postsDto = _mapper.Map<PostDto>(post);

        return postsDto!;
    }

    public async Task CreatePost(CreatePostDto dto)
    {
        var createdPost = _mapper.Map<Post>(dto);

        await _postRepository.CreatePost(createdPost);
    }
}
