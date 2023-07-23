namespace HomieCore.Contracts.Task;

public record UpsertTaskRequest(
    int Id,
    string TaskName,
    string TaskDescription,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);