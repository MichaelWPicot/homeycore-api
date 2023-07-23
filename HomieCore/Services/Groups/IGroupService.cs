using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Groups;

public interface IGroupService
{
    Task<ErrorOr<Created>> CreateGroup(HomieCore.Data.Group group);
    ErrorOr<HomieCore.Data.Group> GetGroup(int id);
    Task<ErrorOr<Deleted>> DeleteGroup(int id);
    Task<ErrorOr<UpsertedGroup>> UpsertGroup(HomieCore.Data.Group group);
    List<HomieCore.Data.Group> GetAllGroup();
}