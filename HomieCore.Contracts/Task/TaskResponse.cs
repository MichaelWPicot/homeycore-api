namespace HomieCore.Contracts.Task;

public record TaskResponse(
    int Id,
    string TaskName,
    string TaskDescription,
    DateTime LastModifiedTime,
    DateTime TaskCreatedDate,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);

public record FilteredResponse(
    int Id,
    string TaskName,
    string TaskDescription,
    DateTime TaskCreatedDate,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);