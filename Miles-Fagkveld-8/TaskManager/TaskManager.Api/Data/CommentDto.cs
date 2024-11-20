namespace TaskManager.Api.Data
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TodoItemDto? TodoListItem { get; set; }
        public int? TodoListItemId { get; set; }
    }
}
