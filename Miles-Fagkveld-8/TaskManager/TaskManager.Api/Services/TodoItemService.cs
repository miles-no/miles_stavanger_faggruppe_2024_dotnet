using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class TodoItemService(ITodoItemRepository repository) : ITodoItemService
    {
        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            var todoItemDtos = await repository.GetTodoItemsAsync();
            return todoItemDtos.Select(dto => new TodoItem
            {
                Id = dto.Id,
                Name = dto.Name,
                IsComplete = dto.IsComplete,
                CategoryId = dto.Category?.Id,
            });
        }

        public async Task<TodoItem> GetTodoItemAsync(int id)
        {
            var dto = await repository.GetTodoItemAsync(id);
            return new TodoItem
            {
                Id = dto.Id,
                Name = dto.Name,
                IsComplete = dto.IsComplete
            };
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            var dto = new TodoItemDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
            await repository.AddTodoItemAsync(dto);
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            var dto = new TodoItemDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
            await repository.UpdateTodoItemAsync(dto);
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