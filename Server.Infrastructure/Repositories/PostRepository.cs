using Microsoft.EntityFrameworkCore;
using Server.Domain.Entity.Content;
using Server.Domain.Repositories;

namespace Server.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    AppDbContext _dbContext;

    public PostRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Post>> GetAllAsync()
    {
        var posts = await _dbContext.Post.ToListAsync();
        return posts;
    }

    public async Task<Post?> GetByIdAsync(Guid slug)
    {
        var post = await _dbContext.Post.FirstOrDefaultAsync(x => x.Id == slug);

        return post;
    }
}
