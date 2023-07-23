namespace HomieCore.Contracts.Task;

public record CreateTaskRequest(
    string TaskName,
    string TaskDescription,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);