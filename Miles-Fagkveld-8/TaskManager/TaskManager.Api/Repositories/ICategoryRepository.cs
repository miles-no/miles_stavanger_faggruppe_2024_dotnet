using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
    }
}

