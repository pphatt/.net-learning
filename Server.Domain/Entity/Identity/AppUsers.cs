using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entity.Identity;

[Table("AppUsers")]
public class AppUsers : IdentityUser<Guid>
{
}
