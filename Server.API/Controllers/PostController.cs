using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.PostApp.Commands.CreatePost;
using Server.Application.Features.PostApp.Commands.DeletePost;
using Server.Application.Features.PostApp.Queries.GetAllPost;
using Server.Application.Features.PostApp.Queries.GetPostById;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Server.API.Controllers;

[ApiController]
[Route("/posts")]
public class PostController : ControllerBase
{
    IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all the posts", Description = "Get all the available post in the database.")]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _mediator.Send(new GetAllPostQuery());

        if (!posts.Any())
        {
            return NotFound();
        }

        return Ok(posts);
    }

    [HttpGet("/post/{id}")]
    [SwaggerOperation(Summary = "Get the details of a specific post", Description = "Take a post id in order to retrieve.")]
    public async Task<IActionResult> GetPostById([FromRoute, SwaggerParameter(Description = "Post's Id", Required = true), DefaultValue("D7004D08-2DAB-487B-5DED-08DD2A71BF93")] Guid id)
    {
        var post = await _mediator.Send(new GetPostByIdQuery(id));

        if(post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetPostById), new { id }, "Created new post successfully");
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePost([FromBody] DeletePostCommand command)
    {
        var isDeleted = await _mediator.Send(command);

        if (isDeleted)
        {
            return Ok("Delete post successfully");
        }

        return NotFound("Post id was not found");
    }
}
