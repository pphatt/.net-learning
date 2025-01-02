using Microsoft.AspNetCore.Mvc;
using Server.Domain.Features;

namespace Server.API.Controllers;

[ApiController]
[Route("/posts")]
public class PostController : ControllerBase
{
    IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }
}
