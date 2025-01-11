using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Comments;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;

namespace Server.Application.Features.CommentApp.Queries.GetAllPostComments;

public class GetAllPostCommentsQueryHandler : IRequestHandler<GetAllPostCommentsQuery, List<PostCommentsDto>>
{
    ILogger<GetAllPostCommentsQueryHandler> _logger;
    IMapper _mapper;
    ICommentRepository _commentRepository;

    public GetAllPostCommentsQueryHandler(ILogger<GetAllPostCommentsQueryHandler> logger, IMapper mapper, ICommentRepository commentRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _commentRepository = commentRepository;
    }

    public async Task<List<PostCommentsDto>> Handle(GetAllPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAllPostComments(request.PostId);

        var commentsDto = _mapper.Map<List<PostCommentsDto>>(comments);

        return commentsDto;
    }
}
