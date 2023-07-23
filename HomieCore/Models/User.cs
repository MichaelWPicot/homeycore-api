using HomieCore.Contracts.User;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public sealed class User{
    public const int MinNameLength=2;
    public const int MaxNameLength=20;
    public int Id {get;}
    public string FirstName {get;}
    public string LastName {get;}
    public DateTime LastModifiedDateTime {get;}

    private User(
        int id,
        string firstName,
        string lastName,
        DateTime lastModifiedTime
    ){
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        LastModifiedDateTime = lastModifiedTime;
    }
    public static ErrorOr<User> Create(
        string firstName,
        string lastName,
        int? id = null
    )
    {
        List<Error> errors = new();
        if (firstName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.User.InvalidName);
        }
          if (lastName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.User.InvalidName);
        }
        if (errors.Count>0){
            return errors;
        }
        return new User(
            id ?? BitConverter.ToInt32(Guid.NewGuid().ToByteArray()),
            firstName,
            lastName,
            DateTime.UtcNow
        );
    }
       public static ErrorOr<User> From(CreateUserRequest request)
    {
        return Create(
            request.FirstName,
            request.LastName);
    }

    public static ErrorOr<User> From(int id, UpsertUserRequest request)
    {
        return Create(
            request.FirstName,
            request.LastName,
            id);
    }
}
