using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;

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

    public async Task<Boolean> DeletePost(Guid id)
    {
        var row = await _dbContext.Post.Where(p => p.Id == id).ExecuteDeleteAsync();

        return row > 0 ? true : false;
    }
}
