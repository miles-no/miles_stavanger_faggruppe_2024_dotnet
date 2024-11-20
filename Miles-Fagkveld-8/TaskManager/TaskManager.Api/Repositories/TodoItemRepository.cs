using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public class TodoItemRepository(TaskManagerContext context) : ITodoItemRepository
    {
        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync()
        {
            return await context.TodoItems.Include(t => t.Category).ToListAsync();
        }

        public async Task<TodoItemDto> GetTodoItemAsync(int id)
        {
            return await context.TodoItems.FindAsync(id);
        }

        public async Task AddTodoItemAsync(TodoItemDto todoItem)
        {
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTodoItemAsync(TodoItemDto todoItem)
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
