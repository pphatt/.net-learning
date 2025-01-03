using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entity.Content;

public class Post : BaseEntity
{
    [Required]
    public string Title {  get; set; }

    [Required]
    public string Content { get; set; } = default!;

    [Required]
    public string Slug { get; set; }

    [Required]
    public List<PostComments> PostComments { get; set; }

    [Required]
    public List<PostLikes> PostLikes { get; set; }
}
