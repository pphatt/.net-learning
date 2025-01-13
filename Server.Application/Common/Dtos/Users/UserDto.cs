namespace Server.Application.Common.Dtos.Users;

public record UserDto
{
    public string _Id { get; set; }

    public string _Email { get; set; }

    public List<string> _Roles { get; set; }

    public UserDto(string Id, string Email, List<string> Roles) 
    {
        _Id = Id;
        _Email = Email;
        _Roles = Roles;
    }

    public bool IsInRoles(string role) => _Roles.Contains(role);
}
