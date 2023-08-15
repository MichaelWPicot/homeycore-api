using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.GroupTask;

public interface IGroupTaskService
{
    Task<ErrorOr<Created>> CreateGroupTask(HomieCore.Data.GroupTask groupTask);
    ErrorOr<HomieCore.Data.GroupTask> GetGroupTask(int id);
    ErrorOr<List<HomieCore.Data.GroupTask>> GetGroupTasksByGroup(int id);
    Task<ErrorOr<Deleted>> DeleteGroupTask(int id);
    Task<ErrorOr<UpsertedGroupTask>> UpsertGroupTask(HomieCore.Data.GroupTask groupTask, int urlTasksId);
    List<HomieCore.Data.GroupTask> GetAllGroupTask();
}