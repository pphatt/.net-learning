using MediatR;
using Server.Application.Common.Dtos.Posts;

namespace Server.Application.Features.PostApp.Queries.GetAllPost;

public class GetAllPostQuery : IRequest<List<PostDto>>
{
}
