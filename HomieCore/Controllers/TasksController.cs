using Microsoft.AspNetCore.Mvc;
using HomieCore.Contracts.Task;
using HomieCore.Models;
using HomieCore.Services.Tasks;
using HomieCore.ServiceErrors;
using ErrorOr;
namespace HomieCore.Controllers;

public class TasksController : ApiController
{
    //inject service dependancy
    private readonly ITaskService _taskService;
    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpPost]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
        ErrorOr<HomieCore.Models.Task> requestToTaskResult = HomieCore.Models.Task.From(request);
        if (requestToTaskResult.IsError)
        {
            return Problem(requestToTaskResult.Errors);
        }
        var task = requestToTaskResult.Value;
        HomieCore.Data.Task modelTransformTask = MapModelToData(task);
        Task<ErrorOr<Created>> createTaskResult = _taskService.CreateTask(modelTransformTask);
        return createTaskResult.Result.Match(
            _ => CreatedAtGetDataTask(MapModelToData(task)),
            errors => Problem(errors));
    }
     [HttpGet("{id:int}")]
     public IActionResult GetTask(int id){
        var getTaskResult = _taskService.GetTask(id);
        return getTaskResult.Match(
            task => Ok(MapTaskDataResponse(task)),
            errors => Problem(errors)
        );
     }
    [HttpGet("")]
    public IActionResult GetAllTask(){
       List<HomieCore.Data.Task> getAllTaskResult = _taskService.GetAllTask();
        return Ok(getAllTaskResult);
     }
    [HttpPut("{id:int}")]
    public IActionResult UpsertTask(int id, UpsertTaskRequest request)
    {
        ErrorOr<HomieCore.Models.Task> requestToTaskResult = HomieCore.Models.Task.From( id, request);
        if (requestToTaskResult.IsError){
            return Problem(requestToTaskResult.Errors);
        }
        var task = requestToTaskResult.Value;
        HomieCore.Data.Task modelTaskTransform = MapModelToData(task);
        Task<ErrorOr<UpsertedTask>> upsertedTaskResult = _taskService.UpsertTask(modelTaskTransform);
        return upsertedTaskResult.Result.Match(
            upserted => upserted.IsNewTask ? CreatedAtGetDataTask(MapModelToData(task)) : NoContent(),
            errors => Problem (errors)
        );
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteTask(int id)
    {
        Task<ErrorOr<Deleted>> deletedTaskResult= _taskService.DeleteTask(id);
        return deletedTaskResult.Result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static FilteredResponse MapTaskDataResponse(HomieCore.Data.Task task){
            return new FilteredResponse(
                task.TaskName,
                task.TaskDescription
            );
        }
     private CreatedAtActionResult CreatedAtGetDataTask(HomieCore.Data.Task task)
    {
        return CreatedAtAction(
            actionName: nameof(GetTask),
            routeValues: new {id = task.Id},
            value: MapTaskDataResponse(task)
        );
    }
    private static HomieCore.Data.Task MapModelToData(HomieCore.Models.Task task){
        return  new HomieCore.Data.Task{
        Id=task.Id,
        TaskName=task.TaskName,
        TaskDescription=task.TaskDescription,
        CompleteByDate=task.CompleteByDate,
        TaskCreatedDate=task.TaskCreatedDate,
        LastModifiedDateTime=task.LastModifiedDateTime,
        CreatedUserId=task.CreatedUserId,
        AssignedUserId=task.AssignedUserId};
    }
}