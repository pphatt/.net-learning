using Server.Application.Common.Dtos.Comments;
using Server.Application.Common.Dtos.Reactions;
using Server.Domain.Entity.Content;

namespace Server.Application.Common.Dtos.Posts;

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Slug { get; set; }
    public List<PostCommentsDto> PostComments { get; set; } = new List<PostCommentsDto>();
    public List<PostLikesDto> PostLikes { get; set; } = new List<PostLikesDto>();
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
