using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;

namespace Server.Application.Features.CommentApp.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, bool>
{
    ILogger<CreateCommentCommandHandler> _logger;
    IMapper _mapper;
    ICommentRepository _commentRepository;

    public CreateCommentCommandHandler(ILogger<CreateCommentCommandHandler> logger, IMapper mapper, ICommentRepository commentRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _commentRepository = commentRepository;
    }

    public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<CreateCommentCommand, PostComments>(request);
        var id = await _commentRepository.CreateComment(comment);

        return true;
    }
}
