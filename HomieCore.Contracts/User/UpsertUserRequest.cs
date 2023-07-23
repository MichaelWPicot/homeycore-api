namespace HomieCore.Contracts.User;

public record UpsertUserRequest(
    string FirstName,
    string LastName
);