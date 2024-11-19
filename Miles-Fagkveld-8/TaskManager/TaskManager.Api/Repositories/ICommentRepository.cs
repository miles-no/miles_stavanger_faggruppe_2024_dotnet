   // File: TaskManager.Api/Repositories/ICommentRepository.cs
   using TaskManager.Api.Models;

   public interface ICommentRepository
   {
       Task<IEnumerable<Comment>> GetCommentsAsync();
       Task<Comment> GetCommentAsync(int id);
       Task AddCommentAsync(Comment comment);
       Task UpdateCommentAsync(Comment comment);
       Task DeleteCommentAsync(int id);
       Task<bool> CommentExistsAsync(int id);
   }
   