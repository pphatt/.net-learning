using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.IdentityApp.Commands.AssignUserRole;
using Server.Application.Features.IdentityApp.Commands.UpdateIdentity;
using Server.Domain.Entity.Identity;

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

    [HttpPost("/role")]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> AssignUserRole([FromForm] AssignUserRoleCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
