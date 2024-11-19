using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public class CategoryRepository(TaskManagerContext context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await context.Categories.AnyAsync(e => e.Id == id);
        }
    }
}