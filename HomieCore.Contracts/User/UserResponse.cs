namespace HomieCore.Contracts.User;


public record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime AccountCreationTime,
    DateTime LastModifiedTime,
    List<string> Groups
);