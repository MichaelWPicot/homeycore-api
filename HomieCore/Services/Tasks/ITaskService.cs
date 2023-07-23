using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Tasks;

public interface ITaskService
{
    Task<ErrorOr<Created>> CreateTask(HomieCore.Data.Task task);
    ErrorOr<HomieCore.Data.Task> GetTask(int id);
    Task<ErrorOr<Deleted>> DeleteTask(int id);
    Task<ErrorOr<UpsertedTask>> UpsertTask(HomieCore.Data.Task task);
    List<HomieCore.Data.Task> GetAllTask();
}