   using TaskManager.Api.Models;

   namespace TaskManager.Api.Services;

   public interface ICommentService
   {
       Task<IEnumerable<Comment>> GetCommentsAsync(int todoListItemId);
       Task<Comment> GetCommentAsync(Guid id);
       Task AddCommentAsync(int todoListItemId, CreateComment comment);
       Task UpdateCommentAsync(Guid id, Comment comment);
       Task DeleteCommentAsync(Guid id);
   }