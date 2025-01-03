using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entity.Content;

public class PostLikes : BaseEntity
{
    [Required]
    public Guid PostId { get; set; }

    [Required]
    public string UserId { get; set; }
}
