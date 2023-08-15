using HomieCore.Contracts.Group;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public sealed class Group{
    public const int MinNameLength=2;
    public const int MaxNameLength=20;
    public const int MaxDescriptionLength=200;
    public int Id {get;}
    public string GroupName {get;}
    public string GroupDescription {get;}
    public DateTime LastModifiedTime {get;}

    private Group(
        int id,
        string groupName,
        string groupDescription,
        DateTime lastModifiedTime
    ){
        Id = id;
        GroupName = groupName;
        GroupDescription = groupDescription;
        LastModifiedTime = lastModifiedTime;
    }

    public static ErrorOr<Group> Create(
        string groupName,
        string groupDescription,
        int? id = null
    ){
        List<Error> errors = new();
        //TODO: Implement error logic
        if (groupName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Group.InvalidName);
        }
          if (groupName.Length is < MinNameLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Group.InvalidName);
        }
        if (errors.Count>0){
            return errors;
        }
        //TODO: Pull current user id and pass in as the sole user in the List.
        return new Group(
            id ?? BitConverter.ToInt32(Guid.NewGuid().ToByteArray()),
            groupName,
            groupDescription,
            DateTime.UtcNow
        );
    }
    public static ErrorOr<Group> From(CreateGroupRequest request)
        {
            return Create(
                request.GroupName,
                request.GroupDescription
            );
        }
    public static ErrorOr<Group> From(int id, UpsertGroupRequest request)
    {
        return Create(
            request.GroupName,
            request.GroupDescription,
            id
        );
    }
}
