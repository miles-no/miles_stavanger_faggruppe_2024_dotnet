   // File: TaskManager.Api/Services/CommentService.cs
   using TaskManager.Api.Models;

   public class CommentService(ICommentRepository commentRepository) : ICommentService
   {
       public async Task<IEnumerable<Comment>> GetCommentsAsync()
       {
           return await commentRepository.GetCommentsAsync();
       }

       public async Task<Comment> GetCommentAsync(int id)
       {
           return await commentRepository.GetCommentAsync(id);
       }

       public async Task AddCommentAsync(Comment comment)
       {
           await commentRepository.AddCommentAsync(comment);
       }

       public async Task UpdateCommentAsync(int id, Comment comment)
       {
           if (id != comment.Id)
           {
               throw new ArgumentException("ID mismatch");
           }

           if (!await commentRepository.CommentExistsAsync(id))
           {
               throw new KeyNotFoundException("Comment not found");
           }

           await commentRepository.UpdateCommentAsync(comment);
       }

       public async Task DeleteCommentAsync(int id)
       {
           if (!await commentRepository.CommentExistsAsync(id))
           {
               throw new KeyNotFoundException("Comment not found");
           }

           await commentRepository.DeleteCommentAsync(id);
       }
   }
   