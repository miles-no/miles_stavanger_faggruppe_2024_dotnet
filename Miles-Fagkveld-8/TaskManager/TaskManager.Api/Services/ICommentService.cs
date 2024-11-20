   using TaskManager.Api.Models;

   namespace TaskManager.Api.Services;

   public interface ICommentService
   {
       Task<IEnumerable<Comment>> GetCommentsAsync(int todoListItemId);
       Task<Comment> GetCommentAsync(int id);
       Task AddCommentAsync(int todoListItemId, Comment comment);
       Task UpdateCommentAsync(int id, Comment comment);
       Task DeleteCommentAsync(int id);
   }