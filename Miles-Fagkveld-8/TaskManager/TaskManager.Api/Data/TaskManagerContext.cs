using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data
{
    public class TaskManagerContext(DbContextOptions<TaskManagerContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}