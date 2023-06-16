namespace HomieCore.Contracts.User;

public record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime LastModifiedTime,
    List<string> Groups
);