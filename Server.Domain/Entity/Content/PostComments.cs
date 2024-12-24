using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entity.Content;

public class PostComments : BaseEntity
{
    [Required]
    public string PostId {  get; set; }

    [Required]
    public string Content { get; set; }
}
