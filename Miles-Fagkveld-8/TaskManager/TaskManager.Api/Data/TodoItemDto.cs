namespace TaskManager.Api.Data
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public CategoryDto? Category { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}