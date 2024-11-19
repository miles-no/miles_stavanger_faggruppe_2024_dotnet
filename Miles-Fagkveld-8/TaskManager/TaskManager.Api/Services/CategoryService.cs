using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(int id, Category category)
        {
            if (id != category.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            if (!await categoryRepository.CategoryExistsAsync(id))
            {
                throw new KeyNotFoundException("Category not found");
            }

            await categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (!await categoryRepository.CategoryExistsAsync(id))
            {
                throw new KeyNotFoundException("Category not found");
            }

            await categoryRepository.DeleteCategoryAsync(id);
        }
    }
}