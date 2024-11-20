using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categoryDtos = await categoryRepository.GetCategoriesAsync();
            return categoryDtos.Select(dto => new Category
            {
                Id = dto.Id,
                Name = dto.Name
                // Map other properties as needed
            });
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var categoryDto = await categoryRepository.GetCategoryByIdAsync(id);
            return new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
                // Map other properties as needed
            };
        }

        public async Task AddCategoryAsync(CreateCategory category)
        {
            var categoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = category.Name
                // Map other properties as needed
            };
            await categoryRepository.AddCategoryAsync(categoryDto);
        }

        public async Task UpdateCategoryAsync(Guid id, Category category)
        {
            if (id != category.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            if (!await categoryRepository.CategoryExistsAsync(id))
            {
                throw new KeyNotFoundException("Category not found");
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
                // Map other properties as needed
            };

            await categoryRepository.UpdateCategoryAsync(categoryDto);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            if (!await categoryRepository.CategoryExistsAsync(id))
            {
                throw new KeyNotFoundException("Category not found");
            }

            await categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
