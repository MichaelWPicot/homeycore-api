using ErrorOr;

namespace HomieCore.ServiceErrors;

public static class Errors
{
    public static class User
    {
        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found"
            );
         public static Error InvalidName => Error.NotFound(
            code: "User.InvalidName",
            description: $"User name must be at least {Models.User.MinNameLength} characters long and at most " +
            $"{Models.User.MaxNameLength} characters long."
            );
    }
    public static class Group {
         public static Error NotFound => Error.NotFound(
            code: "Group.NotFound",
            description: "Group not found"
            );
         public static Error InvalidName => Error.NotFound(
            code: "Group.InvalidName",
            description: $"Group name must be at least {Models.Group.MinNameLength} characters long and at most " +
            $"{Models.Group.MaxNameLength} characters long."
            );
    }
}
