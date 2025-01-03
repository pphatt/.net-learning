using Server.Domain.Entity.Content;

namespace Server.Application.Common.Dtos.Reactions;

public class PostLikesDto
{
    public Guid PostId { get; set; }
    public string UserId { get; set; } = default!;

    public static PostLikesDto? FromEntity(PostLikes? postLikes)
    {
        if (postLikes is null) return null;

        return new PostLikesDto()
        {
            PostId = postLikes.PostId,
            UserId = postLikes.UserId,
        };
    }
}
