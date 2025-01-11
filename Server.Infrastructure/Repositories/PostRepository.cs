using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;
using Server.Infrastructure.Persistence;

namespace Server.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _dbContext;

    public PostRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllAsync()
    {
        var posts = await _dbContext.Post
            .Include(p => p.PostComments)
            .Include(p => p.PostLikes)
            .ToListAsync();

        return posts;
    }

    public async Task<Post?> GetByIdAsync(Guid slug)
    {
        var post = await _dbContext.Post.FirstOrDefaultAsync(x => x.Id == slug);

        return post;
    }

    public async Task<Guid> CreatePost(Post entity) 
    {
        var post = await _dbContext.Post.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeletePost(Post entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
