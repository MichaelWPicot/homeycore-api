using HomieCore.Contracts.Group;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public sealed class Group{
    public const int MinNameLength=2;
    public const int MaxNameLength=20;
    public const int MaxDescriptionLength=200;
    public Guid Id {get;}
    public string GroupName {get;}
    public string GroupDescription {get;}
    public DateTime LastModifiedTime {get;}
    public List<string> Users {get;}
    public List<string> Tasks {get;}

    private Group(
        Guid id,
        string groupName,
        string groupDescription,
        DateTime lastModifiedTime,
        List<string> users,
        List<string> tasks
    ){
        Id = id;
        GroupName = groupName;
        GroupDescription = groupDescription;
        LastModifiedTime = lastModifiedTime;
        Users = users;
        Tasks = tasks;
    }

    public static ErrorOr<Group> Create(
        string groupName,
        string groupDescription,
        List<string>? users = null,
        List<string>? tasks = null,
        Guid? id = null
    ){
        List<Error> errors = new();
        //TODO: Implement error logic
        if (groupName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Group.InvalidName);
        }
          if (groupName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Group.InvalidName);
        }
        if (errors.Count>0){
            return errors;
        }
        //TODO: Pull current user id and pass in as the sole user in the List.
        List<string> emptyUsers = new();
        List<string> emptyTasks = new();
        return new Group(
            id ?? Guid.NewGuid(),
            groupName,
            groupDescription,
            DateTime.UtcNow,
            users ?? emptyUsers,
            tasks ?? emptyTasks
        );
    }
    public static ErrorOr<Group> From(CreateGroupRequest request)
        {
            return Create(
                request.GroupName,
                request.GroupDescription
            );
        }
    public static ErrorOr<Group> From(Guid id, UpsertGroupRequest request)
    {
        return Create(
            request.GroupName,
            request.GroupDescription,
            request.Users,
            request.Tasks,
            id
        );
    }
}
