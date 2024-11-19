namespace TaskManager.Api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required TodoItem TodoItem { get; set; }
    }
}
