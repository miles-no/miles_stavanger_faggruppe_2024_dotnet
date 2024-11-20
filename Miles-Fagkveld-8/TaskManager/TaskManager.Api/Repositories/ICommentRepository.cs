using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories;

public interface ICommentRepository
{

    Task<IEnumerable<CommentEntity>> GetCommentsAsync(int todoItemId);
    Task<CommentEntity> GetCommentAsync(Guid id);
    Task AddCommentAsync(CommentEntity comment);
    Task UpdateCommentAsync(CommentEntity comment);
    Task DeleteCommentAsync(Guid id);
    Task<bool> CommentExistsAsync(Guid id);
}