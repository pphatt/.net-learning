using MediatR;

namespace Server.Application.Features.IdentityApp.Commands.UpdateIdentity;

public class UpdateIdentityCommand : IRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly Dob { get; set; }

    public string Nationality { get; set; }
}
