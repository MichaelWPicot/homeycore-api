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
        HomieCore.Data.Task modelTransformTask = new HomieCore.Data.Task{
        Id=task.Id,
        TaskName=task.TaskName,
        TaskDescription=task.TaskDescription,
        CompleteByDate=task.CompleteByDate,
        // public string TaskDescription { get; set; } = null!;
        // public DateTime CompleteByDate { get; set; }
        // public DateTime TaskCreatedDate { get; set; }
        // public DateTime LastModifiedDateTime { get; set; }
        // public ICollection<GroupTask> GroupTasks { get; set; } = null!;
        // [ForeignKey("CreatedUser")]
        // public int? CreatedUserId { get; set; }
        // public User? CreatedUser { get; set; }
        // [ForeignKey("AssignedUser")]
        // public int? AssignedUserId { get; set; }
        // public User? AssignedUser
        // {
        //     get; set;
        // }
        }
        ErrorOr<Created> createTaskResult = _taskService.CreateTask(modelTransformTask);

        return createTaskResult.Match(
            _ => CreatedAtGetTask(task),
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
    [HttpPut("{id:guid}")]
    public IActionResult UpsertTask(Guid id, UpsertTaskRequest request)
    {
        ErrorOr<HomieCore.Models.Task> requestToTaskResult = HomieCore.Models.Task.From( id, request);
        if (requestToTaskResult.IsError){
            return Problem(requestToTaskResult.Errors);
        }
        var task = requestToTaskResult.Value;
        ErrorOr<UpsertedTask> upsertedTaskResult = _taskService.UpsertTask(task);
        return upsertedTaskResult.Match(
            upserted => upserted.IsNewTask ? CreatedAtGetTask(task) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTask(Guid id)
    {
        ErrorOr<Deleted> deletedTaskResult= _taskService.DeleteTask(id);
        return deletedTaskResult.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static TaskResponse MapTaskResponse(HomieCore.Models.Task task){
            return new TaskResponse(
                task.Id,
                task.TaskName,
                task.TaskDescription,
                task.LastModifiedDateTime,
                task.TaskCreatedDate,
                task.CompleteByDate,
                task.CreatedUserId,
                task.AssignedUserId
            );
        }
         private static FilteredResponse MapTaskDataResponse(HomieCore.Data.Task task){
            return new FilteredResponse(
                task.TaskName,
                task.TaskDescription
            );
        }
    private CreatedAtActionResult CreatedAtGetTask(HomieCore.Models.Task task)
    {
        return CreatedAtAction(
            actionName: nameof(GetTask),
            routeValues: new {id = task.Id},
            value: MapTaskResponse(task)
        );
    }
}