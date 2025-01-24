using Microsoft.AspNetCore.Http;
using Server.Application.Common.Dtos.Users;
using Server.Application.Common.Interfaces.Services;
using Server.Infrastructure.Common.Constants;
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
        var nationality = user.Claims.FirstOrDefault(u => u.Type == AppClaimsTypes.Nationality)?.Value;

        var dobString = user.Claims.FirstOrDefault(u => u.Type == AppClaimsTypes.Dob)?.Value;
        var dob = dobString is null ? (DateOnly?)null : DateOnly.ParseExact(dobString, "dd-MM-yyyy");


        return new UserDto(userId, email, roles, nationality, dob);
    }
}
