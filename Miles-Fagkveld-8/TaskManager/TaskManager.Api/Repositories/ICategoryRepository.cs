using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto CategoryDto);
        Task UpdateCategoryAsync(CategoryDto CategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
    }
}

