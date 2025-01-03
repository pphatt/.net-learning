using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entity.Content;

public class PostComments : BaseEntity
{
    [Required]
    public Guid PostId {  get; set; }

    [Required]
    public string UserId { set; get; } = default!;

    [Required]
    public string Content { get; set; } = default!;
}
