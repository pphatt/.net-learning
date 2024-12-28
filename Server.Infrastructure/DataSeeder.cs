using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Domain.Entity.Content;

namespace Server.Infrastructure;

public class DataSeeder
{
    public async static Task SeedData(AppDbContext context)
    {
        if (context == null || !await context.Database.CanConnectAsync())
        {
            //_logger.LogInformation("DB CONTEXT IS MISSING OR CANNOT CONNECT TO DATABASE SERVER");
            return;
        }

        if (!await context.Post.AnyAsync())
        {
            var posts = PostList();
            await context.Post.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<Post> PostList()
    {
        var posts = new List<Post>
        {
            new () 
            {
                Title = "This is a cool post 1",
                Content = "This is the description for the post 1",
                Slug = "test-post-1"
            },
            new ()
            {
                Title = "This is a cool post 2",
                Content = "This is the description for the post 2",
                Slug = "test-post-2"
            },
            new ()
            {
                Title = "This is a cool post 3",
                Content = "This is the description for the post 3",
                Slug = "test-post-3"
            }
        };

        return posts;
    }
}
