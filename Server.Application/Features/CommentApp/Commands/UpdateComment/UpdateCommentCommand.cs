﻿using MediatR;

namespace Server.Application.Features.CommentApp.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest
{
    public Guid Id { get; set; }
    public string Content { get; set; }
}
