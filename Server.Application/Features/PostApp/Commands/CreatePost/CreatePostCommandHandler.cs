using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;

namespace Server.Application.Features.PostApp.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
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

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var mappedPost = _mapper.Map<Post>(request);

        _logger.LogInformation("Create Post: {@Post}", mappedPost);

        var id = await _postRepository.CreatePost(mappedPost);

        return id;
    }
}
