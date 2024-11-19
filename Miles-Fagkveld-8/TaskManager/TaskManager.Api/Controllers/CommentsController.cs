// File: TaskManager.Api/Controllers/CommentsController.cs
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = await commentService.GetCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await commentService.GetCommentAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            await commentService.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            try
            {
                await commentService.UpdateCommentAsync(id, comment);
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
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                await commentService.DeleteCommentAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
