﻿namespace TaskManager.Api.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
