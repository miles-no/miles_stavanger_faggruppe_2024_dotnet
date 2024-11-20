// ICategoryService.cs
using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task AddCategoryAsync(CreateCategory category);
        Task UpdateCategoryAsync(Guid id, Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}

