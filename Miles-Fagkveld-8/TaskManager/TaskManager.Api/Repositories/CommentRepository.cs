   // File: TaskManager.Api/Repositories/CommentRepository.cs
   using Microsoft.EntityFrameworkCore;
   using TaskManager.Api.Data;
   using TaskManager.Api.Models;

   public class CommentRepository(TaskManagerContext context) : ICommentRepository
   {
       public async Task<IEnumerable<Comment>> GetCommentsAsync()
       {
           return await context.Comments.ToListAsync();
       }

       public async Task<Comment> GetCommentAsync(int id)
       {
           return await context.Comments.FindAsync(id);
       }

       public async Task AddCommentAsync(Comment comment)
       {
           context.Comments.Add(comment);
           await context.SaveChangesAsync();
       }

       public async Task UpdateCommentAsync(Comment comment)
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
   