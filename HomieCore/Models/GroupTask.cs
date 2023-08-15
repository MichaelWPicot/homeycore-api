using HomieCore.Contracts.GroupTask;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public sealed class GroupTask{
    public int? GroupsId {get;}
    public int TasksId {get;}

    private GroupTask(
         int tasksId,
        int? groupsId
   
    ){
            TasksId = tasksId;
        GroupsId = groupsId;
    
    }



    public static ErrorOr<GroupTask> Create(
        int tasksId,
        int? groupsId = null
    ){
        List<Error> errors = new();
        //TODO: Implement error logic
       
        if (errors.Count>0){
            return errors;
        }
        return new GroupTask(
            tasksId,
            groupsId
        );
    }
    public static ErrorOr<GroupTask> From(CreateGroupTaskRequest request)
        {
            return Create(
               request.TasksId,
               request.GroupsId
            );
        }
    public static ErrorOr<GroupTask> From(UpsertGroupTaskRequest request)
    {
        return Create(
            request.TasksId,
            request.GroupsId
        );
    }
}
