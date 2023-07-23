using HomieCore.Contracts.Task;
using HomieCore.ServiceErrors;
using ErrorOr;

namespace HomieCore.Models;

public sealed class Task{
    public const int MinNameLength=2;
    public const int MaxNameLength=20;
    public const int MaxDescriptionLength=200;
    public int Id {get;}
    public string TaskName {get;}
    public string TaskDescription {get;}
    public DateTime CompleteByDate{get;}
    public DateTime TaskCreatedDate {get;}
    public DateTime LastModifiedDateTime {get;}
    public int AssignedUserId {get;}
    public int CreatedUserId {get;}
    private Task(
        int id,
        string taskName,
        string taskDescription,
        DateTime lastModifiedDateTime,
        DateTime taskCreatedDate,
        DateTime completeByDate,
        int createdUserId,
        int assignedUserId
    ){
        Id = id;
        TaskName = taskName;
        TaskDescription = taskDescription;
        LastModifiedDateTime = lastModifiedDateTime;
        TaskCreatedDate = taskCreatedDate;
        CompleteByDate = completeByDate;
        CreatedUserId = createdUserId;
        AssignedUserId = assignedUserId;
    }

    public static ErrorOr<Task> Create(
        string taskName,
        string taskDescription,
        DateTime completeByDate,
        int createdUserId,
        int assignedUserId,
        int? id = null
    ){
        List<Error> errors = new();
        //TODO: Implement error logic
        if (taskName.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Task.InvalidName);
        }
          if (taskDescription.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Task.InvalidName);
        }
        if (errors.Count>0){
            return errors;
        }
        //TODO: Update related users
        return new Task(
            id ?? BitConverter.ToInt32(Guid.NewGuid().ToByteArray()),
            taskName,
            taskDescription,
            DateTime.UtcNow,
            DateTime.UtcNow,
            completeByDate,
            createdUserId,
            assignedUserId
        );
    }
    public static ErrorOr<Task> From(CreateTaskRequest request)
        {
            return Create(
                request.TaskName,
                request.TaskDescription,
                request.CompleteByDate,
                request.CreatedUserId,
                request.AssignedUserId
            );
        }
    public static ErrorOr<Task> From(int id, UpsertTaskRequest request)
    {
        return Create(
            request.TaskName,
            request.TaskDescription,
            request.CompleteByDate,
            request.CreatedUserId,
            request.AssignedUserId,
            id
        );
    }

    public static explicit operator Task(Data.Task v)
    {
        throw new NotImplementedException();
    }
}
