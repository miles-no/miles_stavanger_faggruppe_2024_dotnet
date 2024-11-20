using FastEndpoints;
using TaskManager.Api.Services;

namespace TaskManager.Api.Features.TodoItem.AddTodoItem
{
    public class AddTodoItemEndpoint(ITodoItemService todoItemService) : Endpoint<AddTodoItemRequest, AddTodoItemResponse, AddTodoItemMapper>
    {
        public override void Configure()
        {
            Post("/api/todoitems/v2/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddTodoItemRequest req, CancellationToken ct)
        {
            var todoItem = Map.ToEntity(req);
            await todoItemService.AddTodoItemAsync(todoItem);

            await SendAsync(Map.FromEntity(todoItem), cancellation: ct);
        }
    }
}
