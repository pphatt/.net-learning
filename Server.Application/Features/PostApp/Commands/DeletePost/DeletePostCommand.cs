using MediatR;

namespace Server.Application.Features.PostApp.Commands.DeletePost;

public class DeletePostCommand : IRequest
{
    public Guid Id { get; set; }
}
