using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemAsync(int id);
        Task AddTodoItemAsync(TodoItem todoItem);
        Task UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(int id);
        Task<bool> TodoItemExistsAsync(int id);
    }
}
