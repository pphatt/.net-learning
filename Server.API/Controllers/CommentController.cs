using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.CommentApp.Commands.CreateComment;
using Server.Application.Features.CommentApp.Commands.UpdateComment;

namespace Server.API.Controllers;

[ApiController]
[Route("/comment")]
public class CommentController : ControllerBase
{
    IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
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
