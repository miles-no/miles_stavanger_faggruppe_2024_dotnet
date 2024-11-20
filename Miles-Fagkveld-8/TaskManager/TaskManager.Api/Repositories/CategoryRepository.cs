using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public class CategoryRepository(TaskManagerContext context) : ICategoryRepository
    {
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(CategoryDto CategoryDto)
        {
            context.Categories.Add(CategoryDto);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryDto CategoryDto)
        {
            context.Entry(CategoryDto).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var CategoryDto = await context.Categories.FindAsync(id);
            if (CategoryDto != null)
            {
                context.Categories.Remove(CategoryDto);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoryExistsAsync(Guid id)
        {
            return await context.Categories.AnyAsync(e => e.Id == id);
        }
    }
}