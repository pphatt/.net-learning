using Server.Application.Common.Dtos.Reactions;
using Server.Domain.Entity.Content;

namespace Server.Application.Common.Dtos.Comments;

public class PostCommentsDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public string UserId { set; get; } = default!;
    public string Content { get; set; } = default!;
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
