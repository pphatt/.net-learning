using MediatR;
using Server.Application.Common.Dtos.Comments;

namespace Server.Application.Features.CommentApp.Queries.GetAllPostComments;

public class GetAllPostCommentsQuery : IRequest<List<PostCommentsDto>>
{
    public Guid PostId { get; set; }
}
