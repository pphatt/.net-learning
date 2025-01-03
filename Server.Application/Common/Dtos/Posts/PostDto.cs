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

    public static PostDto? FromEntity(Post? post)
    {
        if (post is null) return null;

        return new PostDto()
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Slug = post.Slug,
            PostComments = post.PostComments.Select(PostCommentsDto.FromEntity).ToList()!,
            PostLikes = post.PostLikes.Select(PostLikesDto.FromEntity).ToList()!,
            DateCreated = post.DateCreated,
            DateUpdated = post.DateUpdated,
        };
    }
}
