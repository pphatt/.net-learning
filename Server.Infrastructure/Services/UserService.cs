using Microsoft.AspNetCore.Http;
using Server.Application.Common.Dtos.Users;
using Server.Application.Common.Interfaces.Services;
using System.Security.Claims;

namespace Server.Infrastructure.Services;

public class UserService : IUserService
{
    IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAuthenticated() 
        => _httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ?? false;

    public UserDto? CurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            throw new Exception("User context is not found");
        }

        if (user.Identity is null || !IsAuthenticated()) 
        {
            return null;
        }

        var userId = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role)!.Select(r => r.Value).ToList();

        return new UserDto(userId, email, roles);
    }
}
