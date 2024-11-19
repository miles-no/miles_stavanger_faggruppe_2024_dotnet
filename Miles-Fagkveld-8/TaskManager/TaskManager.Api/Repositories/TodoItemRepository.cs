using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public class TodoItemRepository(TaskManagerContext context) : ITodoItemRepository
    {
        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemAsync(int id)
        {
            return await context.TodoItems.FindAsync(id);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            context.Entry(todoItem).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                context.TodoItems.Remove(todoItem);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> TodoItemExistsAsync(int id)
        {
            return await context.TodoItems.AnyAsync(e => e.Id == id);
        }
    }
}
