﻿namespace TaskManager.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TodoItem> TodoItems { get; set; }
    }
}
