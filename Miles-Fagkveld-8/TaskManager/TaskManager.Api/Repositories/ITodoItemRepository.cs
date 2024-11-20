using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync();
        Task<TodoItemDto> GetTodoItemAsync(int id);
        Task AddTodoItemAsync(TodoItemDto todoItem);
        Task UpdateTodoItemAsync(TodoItemDto todoItem);
        Task DeleteTodoItemAsync(int id);
        Task<bool> TodoItemExistsAsync(int id);
    }
}
