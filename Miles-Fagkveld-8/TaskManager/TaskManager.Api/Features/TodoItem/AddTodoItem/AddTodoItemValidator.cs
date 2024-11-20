using FastEndpoints;
using FluentValidation;

namespace TaskManager.Api.Features.TodoItem.AddTodoItem
{
    public class AddTodoItemValidator : Validator<AddTodoItemRequest>
    {
        public AddTodoItemValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id is required!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("We need a todo item name!")
                .NotEqual("trash")
                .WithMessage("No trash todo items allowed!");
        }
    }
}
