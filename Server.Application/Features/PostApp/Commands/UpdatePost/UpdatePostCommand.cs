using MediatR;

namespace Server.Application.Features.PostApp.Commands.UpdatePost;

public class UpdatePostCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}
