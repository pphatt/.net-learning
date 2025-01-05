using MediatR;

namespace Server.Application.Features.PostApp.Commands.DeletePost;

public class DeletePostCommand : IRequest<Boolean>
{
    public Guid Id { get; set; }
}
