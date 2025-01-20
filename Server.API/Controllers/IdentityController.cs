using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.IdentityApp.Commands.UpdateIdentity;

namespace Server.API.Controllers;

[ApiController]
[Route("/api/identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch("user")]
    public async Task<IActionResult> UpdateUserDetails(UpdateIdentityCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
