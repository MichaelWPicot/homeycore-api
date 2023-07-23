namespace HomieCore.Contracts.User;

public record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    DateTime LastModifiedTime
);