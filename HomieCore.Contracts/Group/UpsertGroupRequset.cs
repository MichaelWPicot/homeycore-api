namespace HomieCore.Contracts.Group;

public record UpsertGroupRequest(
    string GroupName,
    string GroupDescription
);