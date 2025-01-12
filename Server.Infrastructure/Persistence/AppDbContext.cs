using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entity.Content;
using Server.Domain.Entity.Identity;

namespace Server.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<AppUsers, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    internal DbSet<Post> Post {  get; set; }

    internal DbSet<PostComments> PostComments { get; set; }

    internal DbSet<PostLikes> PostLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Identity Configuration

        // remove base creating model here to avoid the Identity Configuration cannot apply correctly.

        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
            .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
            .HasKey(x => new { x.UserId });

        #endregion Identity Configuration
    }
}
