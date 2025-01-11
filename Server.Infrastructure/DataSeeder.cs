using Microsoft.EntityFrameworkCore;
using Server.Domain.Entity.Content;

namespace Server.Infrastructure.Persistence;

public class DataSeeder
{
    public async static Task SeedData(AppDbContext context)
    {
        if (!await context.Post.AnyAsync())
        {
            var posts = PostList();
            await context.Post.AddRangeAsync(posts);
            await context.SaveChangesAsync();

            // Seed comments and likes after saving posts to the database
            var postComments = new List<PostComments>();
            var postLikes = new List<PostLikes>();

            foreach (var post in posts)
            {
                postComments.AddRange(new[]
                {
                    new PostComments { PostId = post.Id, UserId = "1", Content = "Comment 1 on " + post.Title },
                    new PostComments { PostId = post.Id, UserId = "2", Content = "Comment 2 on " + post.Title }
                });

                postLikes.AddRange(new[]
                {
                    new PostLikes { PostId = post.Id, UserId = "1" },
                    new PostLikes { PostId = post.Id, UserId = "2" }
                });
            }

            await context.PostComments.AddRangeAsync(postComments);
            await context.PostLikes.AddRangeAsync(postLikes);

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
                Slug = "test-post-1",
                PostComments = new List<PostComments>(),
                PostLikes = new List<PostLikes>()
            },
            new ()
            {
                Title = "This is a cool post 2",
                Content = "This is the description for the post 2",
                Slug = "test-post-2",
                PostComments = new List<PostComments>(),
                PostLikes = new List<PostLikes>()
            },
            new ()
            {
                Title = "This is a cool post 3",
                Content = "This is the description for the post 3",
                Slug = "test-post-3",
                PostComments = new List<PostComments>(),
                PostLikes = new List<PostLikes>()
            }
        };

        return posts;
    }
}
