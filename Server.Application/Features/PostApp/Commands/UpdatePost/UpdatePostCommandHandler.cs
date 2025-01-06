using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.PostApp.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, bool>
{
    ILogger<UpdatePostCommandHandler> _logger;
    IMapper _mapper;
    IPostRepository _postRepository;

    public UpdatePostCommandHandler(ILogger<UpdatePostCommandHandler> logger, IMapper mapper, IPostRepository postRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
        _logger.LogInformation("Before updated post details: {@Post}", post);

        if (post is null)
        {
            return false;
        }

        _mapper.Map(request, post);
        //post.Title = request.Title;
        //post.Content = request.Content;

        await _postRepository.CompleteAsync();

        _logger.LogInformation("After updated post details: {@Post}", post);

        return true;
    }
}
