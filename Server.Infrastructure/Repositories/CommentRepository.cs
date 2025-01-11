using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Content;
using Server.Infrastructure.Persistence;

namespace Server.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    AppDbContext _dbContext;

    public CommentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PostComments?> GetByIdAsync(Guid Id)
    {
        var comment = await _dbContext.PostComments.FirstOrDefaultAsync(x => x.Id == Id);
        return comment;
    }

    public async Task<Guid> CreateComment(PostComments postComments)
    {
        await _dbContext.PostComments.AddAsync(postComments);
        await _dbContext.SaveChangesAsync();

        return postComments.Id;
    }
}
