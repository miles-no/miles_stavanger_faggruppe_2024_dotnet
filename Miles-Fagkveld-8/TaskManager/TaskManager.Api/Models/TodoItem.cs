namespace TaskManager.Api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public Category? Category { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}