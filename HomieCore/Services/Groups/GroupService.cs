using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.Groups;

public class GroupService : IGroupService
{
    private static readonly Dictionary<Guid, Group> _groups = new();
    public ErrorOr<Created> CreateGroup(Group group)
    {
        _groups.Add(group.Id, group);

        return Result.Created;
    }
    public ErrorOr<Group> GetGroup(Guid id)
    {
        if(_groups.TryGetValue(id, out var group))
        {
            return group;
        }
       return Errors.Group.NotFound;
    }
    public ErrorOr<Deleted> DeleteGroup(Guid id){
        //TODO: remove group from all users that they are in.
        _groups.Remove(id);
        return Result.Deleted;
    }
    public ErrorOr<UpsertedGroup> UpsertGroup(Group group)
    {
        var IsNewGroup = !_groups.ContainsKey(group.Id);
        _groups[group.Id]= group;
        return new UpsertedGroup(IsNewGroup);
    }
}