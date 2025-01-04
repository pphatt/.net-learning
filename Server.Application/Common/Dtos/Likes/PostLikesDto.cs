using Server.Domain.Entity.Content;

namespace Server.Application.Common.Dtos.Reactions;

public class PostLikesDto
{
    public Guid PostId { get; set; }
    public string UserId { get; set; } = default!;
}
