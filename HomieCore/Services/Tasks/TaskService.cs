using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.Tasks;

public class TaskService : ITaskService
{
    private readonly HomieCore.Data.DataContext _dataContext;
    public TaskService(HomieCore.Data.DataContext dataContext){
        _dataContext = dataContext;
    }
    public async Task<ErrorOr<Created>> CreateTask(HomieCore.Data.Task task)
    {
        _dataContext.Tasks.Add(task);
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Created;
        } else {
            return Error.Failure("General.Failure");
        }
    }
    public ErrorOr<HomieCore.Data.Task> GetTask(int id)
    {
        HomieCore.Data.Task? taskData = _dataContext.Tasks.Where(x => x.Id == id).FirstOrDefault();
        return taskData ?? (ErrorOr<Data.Task>)Errors.Task.NotFound;
    }
     public List<HomieCore.Data.Task> GetAllTask()
    {
        var taskData = _dataContext.Tasks.ToList();
        return taskData;
    }
    public async Task<ErrorOr<Deleted>> DeleteTask(int id){
        //TODO: remove task from group that they are in.
        _dataContext.Remove(_dataContext.Tasks.Single(t=> t.Id ==id));
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Deleted;
        } else {
            return Error.Failure("General.Failure");
        }
    }
    public async Task<ErrorOr<UpsertedTask>> UpsertTask(HomieCore.Data.Task task)
    {
        HomieCore.Data.Task? taskExists = await _dataContext.Tasks.FindAsync(task.Id);
        if (taskExists!=null){
            taskExists.AssignedUserId = task.AssignedUserId;
            taskExists.CreatedUserId = task.CreatedUserId;
            taskExists.TaskName = task.TaskName;
            taskExists.TaskDescription =task.TaskDescription;
            taskExists.CompleteByDate=task.CompleteByDate;
            taskExists.LastModifiedDateTime=DateTime.UtcNow;
            int changes = await _dataContext.SaveChangesAsync();
            if (changes>0){
                return new UpsertedTask(false);
            } else {
                return Error.Failure("General.Failure");
            }
        } else {
            _dataContext.Tasks.Add(task);
            int changes = await _dataContext.SaveChangesAsync();
             if (changes>0){
                return new UpsertedTask(true);
            } else {
                return Error.Failure("General.Failure");
            }
        }
    }
}