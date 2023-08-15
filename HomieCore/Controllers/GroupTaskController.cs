using Microsoft.AspNetCore.Mvc;
using HomieCore.Contracts.GroupTask;
using HomieCore.Models;
using HomieCore.Services.GroupTask;
using HomieCore.ServiceErrors;
using HomieCore.Data;
using ErrorOr;

namespace HomieCore.Controllers;

public class GroupTaskController : ApiController
{
    //inject service dependancy
    private readonly IGroupTaskService _groupTaskService;
    public GroupTaskController(IGroupTaskService groupTaskService)
    {
        _groupTaskService = groupTaskService;
    }
    [HttpPost]
    public IActionResult CreateGroupTask(CreateGroupTaskRequest request)
    {
        ErrorOr<HomieCore.Models.GroupTask> requestToGroupTaskResult = HomieCore.Models.GroupTask.From(request);
        if (requestToGroupTaskResult.IsError)
        {
            return Problem(requestToGroupTaskResult.Errors);
        }
        var groupTask = requestToGroupTaskResult.Value;
        HomieCore.Data.GroupTask modelTransformGroupTask = MapModelToData(groupTask);
        Task<ErrorOr<Created>> createGroupTaskResult = _groupTaskService.CreateGroupTask(MapModelToData(groupTask));
        return createGroupTaskResult.Result.Match(
            _ => CreatedAtGetGroupTask(MapModelToData(groupTask)),
            errors => Problem(errors));
    }
     [HttpGet("{tasksId:int}/{groupsId:int?}")]
    public IActionResult GetGroupTask(int tasksId, int? groupsId = null)
    {
        ErrorOr<HomieCore.Data.GroupTask> getGroupTaskResult = _groupTaskService.GetGroupTask(tasksId);
        return getGroupTaskResult.Match(
            groupTask => Ok(groupTask),
            errors => Problem(errors)
        );
    }
    [HttpGet("ByGroup/{groupsId:int}")]
        public IActionResult GetGroupTasksByGroup(int groupsId)
        {
        ErrorOr<List<HomieCore.Data.GroupTask>> getGroupTaskResult = _groupTaskService.GetGroupTasksByGroup(groupsId);
        return getGroupTaskResult.Match(
            groupTasks => Ok(groupTasks),
            errors => Problem(errors)
        );
        }
    [HttpGet("")]
    public IActionResult GetAllGroupTask()
    {
        List<HomieCore.Data.GroupTask> getGroupTaskResult = _groupTaskService.GetAllGroupTask();
        return Ok(getGroupTaskResult);
    }
    [HttpPut("{tasksId:int}/{groupsId:int?}")]
       public IActionResult UpsertGroupTask(int tasksId, int? groupsId, UpsertGroupTaskRequest request)
    {
       ErrorOr<HomieCore.Models.GroupTask> requestToGroupTaskResult = HomieCore.Models.GroupTask.From(request);
        if (requestToGroupTaskResult.IsError){
            return Problem(requestToGroupTaskResult.Errors);
        }
        var groupTask = requestToGroupTaskResult.Value;
        HomieCore.Data.GroupTask modelGroupTaskTransform = MapModelToData(groupTask);
        Task<ErrorOr<UpsertedGroupTask>> upsertedGroupTaskResult = _groupTaskService.UpsertGroupTask(modelGroupTaskTransform, tasksId);
        return upsertedGroupTaskResult.Result.Match(
            upserted => upserted.IsNewGroupTask ? CreatedAtGetGroupTask(MapModelToData(groupTask)) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroupTask(int id)
    {
        Task<ErrorOr<Deleted>> deletedGroupTaskResult= _groupTaskService.DeleteGroupTask(id);
        return deletedGroupTaskResult.Result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static GroupTaskResponse MapGroupTaskResponse(HomieCore.Data.GroupTask groupTask){
            return new GroupTaskResponse(
                groupTask.GroupsId,
                groupTask.TasksId
            );
        }
    private CreatedAtActionResult CreatedAtGetGroupTask(HomieCore.Data.GroupTask groupTask)
    {
        return CreatedAtAction(
            actionName: nameof(GetGroupTask),
            routeValues: new {tasksId = groupTask.TasksId, groupsId = groupTask.GroupsId},
            value: MapGroupTaskResponse(groupTask)
        );
    }
        private static HomieCore.Data.GroupTask MapModelToData(HomieCore.Models.GroupTask groupTask){
        return  new HomieCore.Data.GroupTask{
        GroupsId=groupTask.GroupsId,
        TasksId=groupTask.TasksId
        };
    }
}
