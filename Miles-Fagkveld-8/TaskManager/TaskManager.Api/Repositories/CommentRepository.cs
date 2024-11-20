using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories;

public class CommentRepository(TaskManagerContext context) : ICommentRepository
{

    public async Task<IEnumerable<CommentDto>> GetCommentsAsync(int todoItemId)
    {
        return await context.Comments.Where(c => c.TodoListItemId == todoItemId).ToListAsync();
    }

    public async Task<CommentDto> GetCommentAsync(Guid id)
    {
        return await context.Comments.FindAsync(id);
    }

    public async Task AddCommentAsync(CommentDto comment)
    {
        context.Comments.Add(comment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCommentAsync(CommentDto comment)
    {
        context.Entry(comment).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment != null)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> CommentExistsAsync(Guid id)
    {
        return await context.Comments.AnyAsync(e => e.Id == id);
    }
}