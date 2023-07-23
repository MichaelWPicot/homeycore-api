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
    private static readonly Dictionary<Guid, HomieCore.Models.Task> _tasks = new();
    public async Task<ErrorOr<Created>> CreateTask(HomieCore.Data.Task task)
    {
        _dataContext.Tasks.Add(task);
        await _dataContext.SaveChangesAsync();

        return Result.Created;
    }
    public ErrorOr<HomieCore.Data.Task> GetTask(int id)
    {
        HomieCore.Data.Task taskData = _dataContext.Tasks.Where(x => x.Id == id).FirstOrDefault();
        if(taskData==null){
            return Errors.Task.NotFound;
        }
        return taskData;
    }
     public List<HomieCore.Data.Task> GetAllTask()
    {
        var taskData = _dataContext.Tasks.ToList();
        return taskData;
    }
    public ErrorOr<Deleted> DeleteTask(Guid id){
        //TODO: remove task from group that they are in.
        _tasks.Remove(id);
        return Result.Deleted;
    }
    public ErrorOr<UpsertedTask> UpsertTask(HomieCore.Models.Task task)
    {
        var IsNewTask = !_tasks.ContainsKey(task.Id);
        _tasks[task.Id]= task;
        return new UpsertedTask(IsNewTask);
    }
}