using ErrorOr;

namespace HomieCore.ServiceErrors;

public static partial class Errors
{
       public static class GroupTask {
         public static Error NotFound => Error.NotFound(
            code: "GroupTask.NotFound",
            description: "GroupTask not found"
            );
            public static Error InvalidGroupsId => Error.Validation(
            code: "GroupTask.InvalidGroupsId",
            description: "The provided GroupsId is not valid or does not exist."
        );

        public static Error TasksIdMismatchError => Error.Validation(
            code: "GroupTask.TasksIdMismatchError",
            description: "The tasksId in the body does not match the tasksId in the URL."
        );
          public static Error TaskAssignmentError => Error.Validation(
            code: "GroupTask.TaskAssignmentError",
            description: "The provided TasksId already exists in GroupTask."
        );
    }
}
