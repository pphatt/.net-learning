using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.PostApp.Queries.GetAllPost;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostDto>>
{
    ILogger<GetAllPostsQueryHandler> _logger;
    IMapper _mapper;
    IPostRepository _postRepository;

    public GetAllPostsQueryHandler(ILogger<GetAllPostsQueryHandler> logger, IMapper mapper, IPostRepository postRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get All Post Here");
        var posts = await _postRepository.GetAllAsync();

        var postsDto = _mapper.Map<List<PostDto>>(posts);

        return postsDto!;
    }
}
