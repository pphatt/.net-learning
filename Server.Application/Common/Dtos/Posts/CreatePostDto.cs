using Server.Application.Common.Dtos.Comments;
using Server.Application.Common.Dtos.Reactions;

namespace Server.Application.Common.Dtos.Posts;

public class CreatePostDto
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
}
