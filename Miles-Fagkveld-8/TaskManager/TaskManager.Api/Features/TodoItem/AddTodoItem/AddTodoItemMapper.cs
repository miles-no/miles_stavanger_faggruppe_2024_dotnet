using FastEndpoints;

namespace TaskManager.Api.Features.TodoItem.AddTodoItem
{
    public class AddTodoItemMapper : Mapper<AddTodoItemRequest, AddTodoItemResponse, Models.TodoItem>
    {
        public override Models.TodoItem ToEntity(AddTodoItemRequest req) => new()
        {
            Id = req.Id,
            Name = req.Name,
            IsComplete = req.IsComplete,
            CategoryId = req.CategoryId
        };

        public override AddTodoItemResponse FromEntity(Models.TodoItem e) => new()
        {
            Id = e.Id,
            Name = e.Name,
            IsComplete = e.IsComplete,
            CategoryId = e.CategoryId,
            Comments = null
        };
    }
}
