   // File: TaskManager.Api/Services/ICommentService.cs
   using TaskManager.Api.Models;

   public interface ICommentService
   {
       Task<IEnumerable<Comment>> GetCommentsAsync();
       Task<Comment> GetCommentAsync(int id);
       Task AddCommentAsync(Comment comment);
       Task UpdateCommentAsync(int id, Comment comment);
       Task DeleteCommentAsync(int id);
   }
   