using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;
using Server.Domain.Exceptions;

namespace Server.Application.Features.PostApp.Queries.GetPostById;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
{
    ILogger<GetPostByIdQueryHandler> _logger;
    IMapper _mapper;
    IPostRepository _postRepository;

    public GetPostByIdQueryHandler(ILogger<GetPostByIdQueryHandler> logger, IMapper mapper, IPostRepository postRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get post here: {request.Id}");
        var post = await _postRepository.GetByIdAsync(request.Id);

        if (post == null) throw new NotFoundException(nameof(Post), request.Id.ToString());

        var postsDto = _mapper.Map<PostDto>(post);

        return postsDto;
    }
}
