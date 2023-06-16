using HomieCore.Contracts.User;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public class User{
    public const int MinNameLength=2;
    public const int MaxNameLength=20;
    public Guid Id {get;}
    public string FirstName {get;}
    public string LastName {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Groups {get;}

    private User(
        Guid id,
        string firstName,
        string lastName,
        DateTime lastModifiedTime,
        List<string> groups
    ){
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        LastModifiedDateTime = lastModifiedTime;
        Groups = groups;
    }
    public static ErrorOr<User> Create(
        string firstName,
        string lastName,
        List<string>? groups = null,
        Guid? id = null
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
        List<String> groupList = new();
        return new User(
            id ?? Guid.NewGuid(),
            firstName,
            lastName,
            DateTime.UtcNow,
            groups ?? groupList
        );
    }
       public static ErrorOr<User> From(CreateUserRequest request)
    {
        return Create(
            request.FirstName,
            request.LastName);
    }

    public static ErrorOr<User> From(Guid id, UpsertUserRequest request)
    {
        return Create(
            request.FirstName,
            request.LastName,
            request.Groups,
            id);
    }
}
