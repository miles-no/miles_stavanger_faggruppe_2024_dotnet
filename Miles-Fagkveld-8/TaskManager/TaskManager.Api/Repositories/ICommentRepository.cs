using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories;

public interface ICommentRepository
{

    Task<IEnumerable<CommentDto>> GetCommentsAsync(int todoItemId);
    Task<CommentDto> GetCommentAsync(Guid id);
    Task AddCommentAsync(CommentDto comment);
    Task UpdateCommentAsync(CommentDto comment);
    Task DeleteCommentAsync(Guid id);
    Task<bool> CommentExistsAsync(Guid id);
}