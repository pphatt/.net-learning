using Microsoft.EntityFrameworkCore;
using Server.Domain.Entity.Content;

namespace Server.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    internal DbSet<Post> Post {  get; set; }

    internal DbSet<PostComments> PostComments { get; set; }

    internal DbSet<PostLikes> PostLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
