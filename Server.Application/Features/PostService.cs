﻿using Microsoft.Extensions.Logging;
using Server.Domain.Entity.Content;
using Server.Domain.Features;
using Server.Domain.Repositories;

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

    public async Task<List<Post>> GetAllPostsAsync()
    {
        _logger.LogInformation("Get All Post Here");
        var posts = await _postRepository.GetAllAsync();
        return posts;
    }

    public async Task<Post> GetById(Guid slug)
    {
        _logger.LogInformation("Get post here");
        var post = await _postRepository.GetByIdAsync(slug);

        return post;
    }
}
