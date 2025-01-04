using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;

namespace Server.Application.Features.PostApp.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
{
    ILogger<CreatePostCommandHandler> _logger;
    IMapper _mapper;
    IPostRepository _postRepository;

    public CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, IMapper mapper, IPostRepository postRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Post");

        var createdPost = _mapper.Map<Post>(request);

        await _postRepository.CreatePost(createdPost);
    }
}
