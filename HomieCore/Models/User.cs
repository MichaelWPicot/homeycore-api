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
    public DateTime AccountCreatedTime {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Groups {get;}


    private User(
  
        Guid id,
        string firstName,
        string lastName,
        DateTime accountCreatedTime,
        DateTime lastModifiedTime,
        List<string> groups
    ){
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        AccountCreatedTime = accountCreatedTime;
        Groups = groups;
    }
    public static ErrorOr<User> Create(
        string firstName,
        string lastName,
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
        List<string> emptyList = new();
        return new User(
            id ?? Guid.NewGuid(),
            firstName,
            lastName,
            DateTime.UtcNow,
            DateTime.UtcNow,
            emptyList
        );
    }
}
