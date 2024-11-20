using Microsoft.EntityFrameworkCore;

namespace TaskManager.Api.Data
{
    public class TaskManagerContext(DbContextOptions<TaskManagerContext> options) : DbContext(options)
    {
        public DbSet<TodoItemDto> TodoItems { get; set; } = null!;

        public DbSet<CategoryDto> Categories { get; set; } = null!;

        public DbSet<CommentDto> Comments { get; set; } = null!;
    }
}