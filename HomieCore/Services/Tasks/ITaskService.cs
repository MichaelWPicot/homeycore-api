using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Tasks;

public interface ITaskService
{
    Task<ErrorOr<Created>> CreateTask(HomieCore.Data.Task task);
    ErrorOr<HomieCore.Data.Task> GetTask(int id);
    ErrorOr<Deleted> DeleteTask(Guid id);
    ErrorOr<UpsertedTask> UpsertTask(HomieCore.Models.Task task);
    List<HomieCore.Data.Task> GetAllTask();
}