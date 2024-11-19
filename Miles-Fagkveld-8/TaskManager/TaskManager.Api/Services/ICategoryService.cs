// ICategoryService.cs
using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(int id, Category category);
        Task DeleteCategoryAsync(int id);
    }
}

