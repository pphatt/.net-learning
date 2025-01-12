using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entity.Content;

[Table("PostComments")]
public class PostComments : BaseEntity
{
    [Required]
    public Guid PostId { get; set; }

    [Required]
    public string UserId { set; get; } = default!;

    [Required]
    public string Content { get; set; } = default!;
}
