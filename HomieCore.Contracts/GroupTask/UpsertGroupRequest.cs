namespace HomieCore.Contracts.GroupTask;

public record UpsertGroupTaskRequest(
    int? GroupsId,
    int TasksId
);