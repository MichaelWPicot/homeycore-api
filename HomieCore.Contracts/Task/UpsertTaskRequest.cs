namespace HomieCore.Contracts.Task;

public record UpsertTaskRequest(
    string TaskName,
    string TaskDescription,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);