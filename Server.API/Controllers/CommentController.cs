using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Common.Dtos.Comments;
using Server.Application.Features.CommentApp.Commands.CreateComment;
using Server.Application.Features.CommentApp.Commands.UpdateComment;
using Server.Application.Features.CommentApp.Queries.GetAllPostComments;

namespace Server.API.Controllers;

[ApiController]
[Route("/api/comment")]
public class CommentController : ControllerBase
{
    IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/api/post/{PostId}/comments")]
    public async Task<ActionResult<List<PostCommentsDto>>> GetPostComments([FromRoute] GetAllPostCommentsQuery query)
    {
        var comments = await _mediator.Send(query);

        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> CommentOnPost([FromBody] CreateCommentCommand command)
    {
        var isCreated = await _mediator.Send(command);

        if (!isCreated) return BadRequest("Cannot comment at the moment.");

        return Ok("Comment successfully.");
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
    {
        await _mediator.Send(command);

        return Ok("Edit comment successfully");
    }
}
