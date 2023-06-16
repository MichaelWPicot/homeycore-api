namespace HomieCore.Contracts.Group;

public record GroupResponse(
    Guid Id,
    string GroupName,
    string GroupDescription,
    List<string> Users,
    List<string> Tasks,
    DateTime LastModifiedTime
);