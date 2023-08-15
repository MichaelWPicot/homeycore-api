using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.GroupTask;

using HomieCore.Data;
using Microsoft.EntityFrameworkCore;

public class GroupTaskService : IGroupTaskService
{
    private readonly HomieCore.Data.DataContext _dataContext;
    public GroupTaskService(HomieCore.Data.DataContext dataContext){
        _dataContext = dataContext;
    }
  public async Task<ErrorOr<Created>> CreateGroupTask(HomieCore.Data.GroupTask groupTask)
    {
         bool taskExists = await _dataContext.GroupTask.AnyAsync(gt => gt.TasksId == groupTask.TasksId);

        if (taskExists)
        {
            return Errors.GroupTask.TaskAssignmentError;
        }
        _dataContext.GroupTask.Add(groupTask);
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Created;
        } else {
            return Error.Failure("General.Failure");
        }
    }
   public ErrorOr<HomieCore.Data.GroupTask> GetGroupTask(int id)
    {
        HomieCore.Data.GroupTask? groupTaskData = _dataContext.GroupTask.Where(x => x.TasksId == id).FirstOrDefault();
        return groupTaskData ?? (ErrorOr<Data.GroupTask>)Errors.GroupTask.NotFound;
    }
     public List<HomieCore.Data.GroupTask> GetAllGroupTask()
    {
        var groupTaskData = _dataContext.GroupTask.ToList();
        return groupTaskData;
    }
      public async Task<ErrorOr<Deleted>> DeleteGroupTask(int id){
        //TODO: remove task from group that they are in.
        var groupTaskToDelete = _dataContext.GroupTask.FirstOrDefault(t => t.TasksId == id);
        if (groupTaskToDelete != null)
        {
            _dataContext.Remove(groupTaskToDelete);
        }
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Deleted;
        } else {
            return Error.Failure("General.Failure");
        }
    }
   public async Task<ErrorOr<UpsertedGroupTask>> UpsertGroupTask(HomieCore.Data.GroupTask groupTask, int urlTasksId)
    {
          if (groupTask.TasksId != urlTasksId)
    {
        return Errors.GroupTask.TasksIdMismatchError; // Define this error in your Errors class
    }
        HomieCore.Data.GroupTask? groupTaskExists = await _dataContext.GroupTask
        .FirstOrDefaultAsync(gt => gt.GroupsId == groupTask.GroupsId && gt.TasksId == groupTask.TasksId);
        if (groupTaskExists!=null){
            groupTaskExists.GroupsId= groupTask.GroupsId;
            groupTaskExists.TasksId = groupTask.TasksId;
            int changes = await _dataContext.SaveChangesAsync();
            if (changes>0){
                return new UpsertedGroupTask(false);
            } else {
                return Error.Failure("General.Failure");
            }
        } else {
            _dataContext.GroupTask.Add(groupTask);
            int changes = await _dataContext.SaveChangesAsync();
             if (changes>0){
                return new UpsertedGroupTask(true);
            } else {
                return Error.Failure("General.Failure");
            }
        }
    }

    public ErrorOr<List<HomieCore.Data.GroupTask>> GetGroupTasksByGroup(int id)
    {
        List<HomieCore.Data.GroupTask> groupTasksData = _dataContext.GroupTask.Where(x => x.GroupsId == id).ToList();

        if (groupTasksData.Count == 0)
        {
            return (ErrorOr<List<Data.GroupTask>>)Errors.GroupTask.NotFound;
        }

        return groupTasksData;
}
}