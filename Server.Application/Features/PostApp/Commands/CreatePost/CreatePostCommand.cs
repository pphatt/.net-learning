﻿using MediatR;

namespace Server.Application.Features.PostApp.Commands.CreatePost;

public class CreatePostCommand : IRequest
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
}
