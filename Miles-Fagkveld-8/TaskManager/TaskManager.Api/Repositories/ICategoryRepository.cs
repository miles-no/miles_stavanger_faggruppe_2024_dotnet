using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<CategoryEntity> GetCategoryByIdAsync(Guid id);
        Task AddCategoryAsync(CategoryEntity categoryEntity);
        Task UpdateCategoryAsync(CategoryEntity categoryEntity);
        Task DeleteCategoryAsync(Guid id);
        Task<bool> CategoryExistsAsync(Guid id);
    }
}

