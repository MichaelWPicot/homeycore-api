namespace HomieCore.Contracts.Group;

public record GroupResponse(
    int Id,
    string GroupName,
    string GroupDescription,
    DateTime LastModifiedTime
);