namespace HomieCore.Contracts.GroupTask;

public record CreateGroupTaskRequest(
    int? GroupsId,
    int TasksId
);