using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entity.Content;

public class Post : BaseEntity
{
    [Required(ErrorMessage = "Post title is required")]
    [StringLength(100, MinimumLength = 5)]
    public string Title { get; set; } = default!;

    [Required(ErrorMessage = "Post content is required")]
    [StringLength(256, MinimumLength = 5)]
    public string Content { get; set; } = default!;

    [Required]
    public string Slug { get; set; } = default!;

    [Required]
    public List<PostComments> PostComments { get; set; } = new List<PostComments>();

    [Required]
    public List<PostLikes> PostLikes { get; set; } = new List<PostLikes>();
}
