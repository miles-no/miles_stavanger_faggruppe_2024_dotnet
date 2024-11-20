using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        public async Task<IEnumerable<Comment>> GetCommentsAsync(int todoListItemId)
        {
            var commentDtos = await commentRepository.GetCommentsAsync(todoListItemId);
            return commentDtos.Select(dto => new Comment
            {
                Id = dto.Id,
                Text = dto.Text
                // Map other properties as needed
            });
        }

        public async Task<Comment> GetCommentAsync(Guid id)
        {
            var commentDto = await commentRepository.GetCommentAsync(id);
            return new Comment
            {
                Id = commentDto.Id,
                Text = commentDto.Text
                // Map other properties as needed
            };
        }

        public async Task AddCommentAsync(int todoListItemId, CreateComment comment)
        {
            var commentDto = new CommentDto
            {
                Id = Guid.NewGuid(),
                Text = comment.Text,
                TodoListItemId = todoListItemId
            };

            await commentRepository.AddCommentAsync(commentDto);
        }

        public async Task UpdateCommentAsync(Guid id, Comment comment)
        {
            if (id != comment.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            if (!await commentRepository.CommentExistsAsync(id))
            {
                throw new KeyNotFoundException("Comment not found");
            }

            var commentDto = new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text
                // Map other properties as needed
            };

            await commentRepository.UpdateCommentAsync(commentDto);
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            if (!await commentRepository.CommentExistsAsync(id))
            {
                throw new KeyNotFoundException("Comment not found");
            }

            await commentRepository.DeleteCommentAsync(id);
        }
    }
}
