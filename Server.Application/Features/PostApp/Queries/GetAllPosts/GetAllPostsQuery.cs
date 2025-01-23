using MediatR;
using Server.Application.Common.Dtos.Posts;

namespace Server.Application.Features.PostApp.Queries.GetAllPost;

public class GetAllPostsQuery : IRequest<List<PostDto>>
{
}
