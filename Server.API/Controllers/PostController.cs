using Microsoft.AspNetCore.Mvc;
using Server.Domain.Features;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

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
    [SwaggerOperation(Summary = "Get all the posts", Description = "Get all the available post in the database.")]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllPostsAsync();

        if (!posts.Any())
        {
            return NotFound();
        }

        return Ok(posts);
    }

    [HttpGet("/post/{Slug}")]
    [SwaggerOperation(Summary = "Get the details of a specific post", Description = "Take a post id in order to retrieve.")]
    public async Task<IActionResult> GetPostById([FromRoute, SwaggerParameter(Description = "Post's Id", Required = true), DefaultValue("D7004D08-2DAB-487B-5DED-08DD2A71BF93")] Guid Slug)
    {
        var post = await _postService.GetById(Slug);

        if(post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }
}
