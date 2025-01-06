using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.PostApp.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Boolean>
{
    ILogger<DeletePostCommandHandler> _logger;
    IPostRepository _postRepository;

    public DeletePostCommandHandler(ILogger<DeletePostCommandHandler> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }

    public Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete PostId: {request.Id}");
        return _postRepository.DeletePost(request.Id);
    }
}
