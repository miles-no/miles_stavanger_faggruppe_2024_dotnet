namespace TaskManager.Api.Features.TodoItem.AddTodoItem
{
    public class AddTodoItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public Guid? CategoryId { get; set; }
        public List<string>? Comments { get; set; }
    }
}
