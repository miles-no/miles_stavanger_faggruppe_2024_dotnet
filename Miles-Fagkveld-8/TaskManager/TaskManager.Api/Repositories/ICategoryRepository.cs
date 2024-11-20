using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task AddCategoryAsync(CategoryDto CategoryDto);
        Task UpdateCategoryAsync(CategoryDto CategoryDto);
        Task DeleteCategoryAsync(Guid id);
        Task<bool> CategoryExistsAsync(Guid id);
    }
}

