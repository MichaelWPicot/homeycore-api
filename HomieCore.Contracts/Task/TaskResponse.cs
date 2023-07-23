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
     string TaskName,
    string TaskDescription
);