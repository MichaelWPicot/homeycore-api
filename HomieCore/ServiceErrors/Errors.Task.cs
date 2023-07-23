using ErrorOr;

namespace HomieCore.ServiceErrors;

public static partial class Errors
{
    public static class Task
    {
        public static Error NotFound => Error.NotFound(
            code: "Task.NotFound",
            description: "Task not found"
            );
         public static Error InvalidName => Error.NotFound(
            code: "Task.InvalidName",
            description: $"Task name must be at least {Models.Task.MinNameLength} characters long and at most " +
            $"{Models.Task.MaxNameLength} characters long."
            );
    }
}
