using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                await categoryService.UpdateCategoryAsync(id, category);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await categoryService.DeleteCategoryAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
