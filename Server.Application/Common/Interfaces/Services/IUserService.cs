using Server.Application.Common.Dtos.Users;

namespace Server.Application.Common.Interfaces.Services;

public interface IUserService
{
    bool IsAuthenticated();
    UserDto? CurrentUser();
}
