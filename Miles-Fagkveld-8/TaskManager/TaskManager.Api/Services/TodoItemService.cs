using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class TodoItemService(ITodoItemRepository repository) : ITodoItemService
    {
        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await repository.GetTodoItemsAsync();
        }

        public async Task<TodoItem> GetTodoItemAsync(int id)
        {
            return await repository.GetTodoItemAsync(id);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await repository.AddTodoItemAsync(todoItem);
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            await repository.UpdateTodoItemAsync(todoItem);
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            await repository.DeleteTodoItemAsync(id);
        }

        public async Task<bool> TodoItemExistsAsync(int id)
        {
            return await repository.TodoItemExistsAsync(id);
        }
    }
}
