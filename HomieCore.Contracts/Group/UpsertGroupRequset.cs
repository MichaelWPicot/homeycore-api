namespace HomieCore.Contracts.Group;

public record UpsertGroupRequest(
    string GroupName,
    string GroupDescription,
    List<string> Users,
    List<string> Tasks
);