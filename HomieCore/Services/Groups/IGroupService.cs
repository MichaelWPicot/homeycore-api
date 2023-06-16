using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Groups;

public interface IGroupService
{
    ErrorOr<Created> CreateGroup(Group group);
    ErrorOr<Group> GetGroup(Guid id);
    ErrorOr<Deleted> DeleteGroup(Guid id);
    ErrorOr<UpsertedGroup> UpsertGroup(Group group);
}