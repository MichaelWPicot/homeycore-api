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
    private readonly DataContext _datacontext;
    public GroupsController(DataContext dataContext){
        _datacontext = dataContext;
    }
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
        ErrorOr<Created> createGroupResult = _groupService.CreateGroup(group);

        return createGroupResult.Match(
            _ => CreatedAtGetGroup(group),
            errors => Problem(errors));
    }
     [HttpGet("{id:guid}")]
    public IActionResult GetGroup(Guid id)
    {
        Console.Write("asd");
        ErrorOr<HomieCore.Models.Group> getGroupResult = _groupService.GetGroup(id);
        Console.Write("asd");
        return getGroupResult.Match(
            group => Ok(MapGroupResponse(group)),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertGroup(Guid id, UpsertGroupRequest request)
    {
        ErrorOr<HomieCore.Models.Group> requestToGroupResult = HomieCore.Models.Group.From( id, request);
        if (requestToGroupResult.IsError){
            return Problem(requestToGroupResult.Errors);
        }
        var group = requestToGroupResult.Value;
        ErrorOr<UpsertedGroup> upsertedGroupResult = _groupService.UpsertGroup(group);
        return upsertedGroupResult.Match(
            upserted => upserted.IsNewGroup ? CreatedAtGetGroup(group) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGroup(Guid id)
    {
        ErrorOr<Deleted> deletedGroupResult= _groupService.DeleteGroup(id);
        return deletedGroupResult.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static GroupResponse MapGroupResponse(HomieCore.Models.Group group){
            return new GroupResponse(
                group.Id,
                group.GroupName,
                group.GroupDescription,
                group.Tasks,
                group.Users,
                group.LastModifiedTime
            );
        }
    private CreatedAtActionResult CreatedAtGetGroup(HomieCore.Models.Group group)
    {
        return CreatedAtAction(
            actionName: nameof(GetGroup),
            routeValues: new {id = group.Id},
            value: MapGroupResponse(group)
        );
    }
}