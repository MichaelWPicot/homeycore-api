namespace HomieCore.Contracts.Task;

public record TaskResponse(
    Guid Id,
    string TaskName,
    string TaskDescription,
    DateTime LastModifiedDateTime,
    DateTime TaskCreatedDate,
    DateTime CompleteByDate,
    int CreatedUserId,
    int AssignedUserId
);

public record FilteredResponse(
     string TaskName,
    string TaskDescription
);