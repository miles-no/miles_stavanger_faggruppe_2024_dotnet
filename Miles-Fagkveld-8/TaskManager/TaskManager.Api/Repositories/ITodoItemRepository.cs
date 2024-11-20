using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItemEntity>> GetTodoItemsAsync();
        Task<TodoItemEntity> GetTodoItemAsync(int id);
        Task AddTodoItemAsync(TodoItemEntity todoItem);
        Task UpdateTodoItemAsync(TodoItemEntity todoItem);
        Task DeleteTodoItemAsync(int id);
        Task<bool> TodoItemExistsAsync(int id);
    }
}
