﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;
using Server.Domain.Exceptions;

namespace Server.Application.Features.CommentApp.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    ILogger<UpdateCommentCommandHandler> _logger;
    IMapper _mapper;
    ICommentRepository _commentRepository;

    public UpdateCommentCommandHandler(ILogger<UpdateCommentCommandHandler> logger, IMapper mapper, ICommentRepository commentRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _commentRepository = commentRepository;

    }

    public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(request.Id);

        if (comment == null) throw new NotFoundException(nameof(Post), request.Id.ToString());

        _logger.LogInformation("");
        _mapper.Map(request, comment);

        await _commentRepository.CompleteAsync();
    }
}
