using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entity.Content;

[Table("PostLikes")]
public class PostLikes : BaseEntity
{
    [Required]
    public Guid PostId { get; set; }

    [Required]
    public string UserId { get; set; } = default!;
}
