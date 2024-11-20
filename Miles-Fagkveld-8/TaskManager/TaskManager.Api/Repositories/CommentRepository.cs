using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories;

public class CommentRepository(TaskManagerContext context) : ICommentRepository
{

    public async Task<IEnumerable<CommentDto>> GetCommentsAsync(int todoListItemId)
    {
        return await context.Comments.Where(c => c.TodoListItemId == todoListItemId).ToListAsync();
    }

    public async Task<CommentDto> GetCommentAsync(int id)
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

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment != null)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> CommentExistsAsync(int id)
    {
        return await context.Comments.AnyAsync(e => e.Id == id);
    }
}