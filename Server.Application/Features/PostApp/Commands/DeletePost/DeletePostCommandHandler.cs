using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;
using Server.Domain.Exceptions;

namespace Server.Application.Features.PostApp.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    ILogger<DeletePostCommandHandler> _logger;
    IPostRepository _postRepository;

    public DeletePostCommandHandler(ILogger<DeletePostCommandHandler> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete PostId: {request.Id}");
        var post = await _postRepository.GetByIdAsync(request.Id);

        if (post == null) throw new NotFoundException(nameof(Post), request.Id.ToString());

        await _postRepository.DeletePost(post);
    }
}
