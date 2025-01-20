using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Services;
using Server.Domain.Entity.Identity;
using Server.Domain.Exceptions;

namespace Server.Application.Features.IdentityApp.Commands.UpdateIdentity;

public class UpdateIdentityCommandHandler : IRequestHandler<UpdateIdentityCommand>
{
    ILogger<UpdateIdentityCommandHandler> _logger;
    IMapper _mapper;
    IUserService _userService;
    IUserStore<AppUsers> _userStore;

    public UpdateIdentityCommandHandler(ILogger<UpdateIdentityCommandHandler> logger, IMapper mapper, IUserService userService, IUserStore<AppUsers> userStore)
    {
        _logger = logger;
        _mapper = mapper;
        _userService = userService;
        _userStore = userStore;
    }

    public async Task Handle(UpdateIdentityCommand request, CancellationToken cancellationToken)
    {
        var isAuthenticated = _userService.IsAuthenticated();

        if (!isAuthenticated) 
        {
            throw new Exception("Unauthorized action");
        }

        var currentUser = _userService.CurrentUser();

        _logger.LogInformation("Updating user: {UserId} with {@Request}", currentUser!._Id, request);

        var user = await _userStore.FindByIdAsync(currentUser._Id, cancellationToken);

        if (user == null) 
        {
            throw new NotFoundException(nameof(AppUsers), currentUser._Id);
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Dob = request.Dob;
        user.Nationality = request.Nationality;

        await _userStore.UpdateAsync(user, cancellationToken);
    }
}
