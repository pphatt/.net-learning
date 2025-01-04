using MediatR;
using Server.Application.Common.Dtos.Posts;

namespace Server.Application.Features.PostApp.Queries.GetPostById;

public class GetPostByIdQuery : IRequest<PostDto>
{
    public Guid Id { get; set; }

    public GetPostByIdQuery(Guid id)
    {
        Id = id;
    }
}
