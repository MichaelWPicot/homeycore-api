using Microsoft.AspNetCore.Mvc;
using HomieCore.Contracts.Group;
using HomieCore.Models;
using HomieCore.Services.Groups;
using HomieCore.ServiceErrors;
using HomieCore.Data;
using ErrorOr;

namespace HomieCore.Controllers;

public class GroupsController : ApiController
{
    //inject service dependancy
    private readonly IGroupService _groupService;
    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }
    [HttpPost]
    public IActionResult CreateGroup(CreateGroupRequest request)
    {
        ErrorOr<HomieCore.Models.Group> requestToGroupResult = HomieCore.Models.Group.From(request);
        if (requestToGroupResult.IsError)
        {
            return Problem(requestToGroupResult.Errors);
        }
        var group = requestToGroupResult.Value;
        HomieCore.Data.Group modelTransformGroup = MapModelToData(group);
        Task<ErrorOr<Created>> createGroupResult = _groupService.CreateGroup(MapModelToData(group));
        return createGroupResult.Result.Match(
            _ => CreatedAtGetGroup(MapModelToData(group)),
            errors => Problem(errors));
    }
     [HttpGet("{id:int}")]
    public IActionResult GetGroup(int id)
    {
        ErrorOr<HomieCore.Data.Group> getGroupResult = _groupService.GetGroup(id);
        return getGroupResult.Match(
            group => Ok(group),
            errors => Problem(errors)
        );
    }
    [HttpGet("")]
    public IActionResult GetAllGroup()
    {
        List<HomieCore.Data.Group> getGroupResult = _groupService.GetAllGroup();
        return Ok(getGroupResult);
    }
    [HttpPut("{id:int}")]
       public IActionResult UpsertGroup(int id, UpsertGroupRequest request)
    {
       ErrorOr<HomieCore.Models.Group> requestToGroupResult = HomieCore.Models.Group.From( id, request);
        if (requestToGroupResult.IsError){
            return Problem(requestToGroupResult.Errors);
        }
        var group = requestToGroupResult.Value;
        HomieCore.Data.Group modelGroupTransform = MapModelToData(group);
        Task<ErrorOr<UpsertedGroup>> upsertedGroupResult = _groupService.UpsertGroup(modelGroupTransform);
        return upsertedGroupResult.Result.Match(
            upserted => upserted.IsNewGroup ? CreatedAtGetGroup(MapModelToData(group)) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroup(int id)
    {
        Task<ErrorOr<Deleted>> deletedGroupResult= _groupService.DeleteGroup(id);
        return deletedGroupResult.Result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static GroupResponse MapGroupResponse(HomieCore.Data.Group group){
            return new GroupResponse(
                group.Id,
                group.GroupName,
                group.GroupDescription,
                group.LastModifiedTime
            );
        }
    private CreatedAtActionResult CreatedAtGetGroup(HomieCore.Data.Group group)
    {
        return CreatedAtAction(
            actionName: nameof(GetGroup),
            routeValues: new {id = group.Id},
            value: MapGroupResponse(group)
        );
    }
        private static HomieCore.Data.Group MapModelToData(HomieCore.Models.Group group){
        return  new HomieCore.Data.Group{
        Id=group.Id,
        GroupName=group.GroupName,
        GroupDescription=group.GroupDescription,
        LastModifiedTime=group.LastModifiedTime
        };
    }
}
