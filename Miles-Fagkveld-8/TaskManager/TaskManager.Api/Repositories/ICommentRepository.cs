using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories;

public interface ICommentRepository
{

    Task<IEnumerable<CommentDto>> GetCommentsAsync(int todoListItemId);
    Task<CommentDto> GetCommentAsync(int id);
    Task AddCommentAsync(CommentDto comment);
    Task UpdateCommentAsync(CommentDto comment);
    Task DeleteCommentAsync(int id);
    Task<bool> CommentExistsAsync(int id);
}