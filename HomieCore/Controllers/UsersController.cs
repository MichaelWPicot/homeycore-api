using Microsoft.AspNetCore.Mvc;
using HomieCore.Contracts.User;
using HomieCore.Models;
using HomieCore.Services.Users;
using HomieCore.ServiceErrors;
using ErrorOr;
namespace HomieCore.Controllers;

public class UsersController : ApiController
{
    //inject service dependancy
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        ErrorOr<HomieCore.Models.User> requestToUserResult = HomieCore.Models.User.From(request);
        if (requestToUserResult.IsError)
        {
            return Problem(requestToUserResult.Errors);
        }
        var user = requestToUserResult.Value;
        HomieCore.Data.User modelTransformUser = MapModelToData(user);
        Task<ErrorOr<Created>> createUserResult = _userService.CreateUser(modelTransformUser);
        return createUserResult.Result.Match(
            _ => CreatedAtGetUser(modelTransformUser),
            errors => Problem(errors));
    }
     [HttpGet("{id:int}")]
    public IActionResult GetUser(int id)
    {
        var getUserResult = _userService.GetUser(id);
        return getUserResult.Match(
            user => Ok(MapUserResponse(user)),
            errors => Problem(errors)
        );
    }
    [HttpGet("")]
    public IActionResult GetAllUser(){
       List<HomieCore.Data.User> getAllUserResult = _userService.GetAllUser();
        return Ok(getAllUserResult);
     }
    [HttpPut("{id:int}")]
    public IActionResult UpsertUser(int id, UpsertUserRequest request)
    {
        ErrorOr<HomieCore.Models.User> requestToUserResult = HomieCore.Models.User.From( id, request);
        if (requestToUserResult.IsError){
            return Problem(requestToUserResult.Errors);
        }
        var user = requestToUserResult.Value;
        HomieCore.Data.User modelUserTransform = MapModelToData(user);
        Task<ErrorOr<UpsertedUser>> upsertedUserResult = _userService.UpsertUser(modelUserTransform);
        return upsertedUserResult.Result.Match(
            upserted => upserted.IsNewUser ? CreatedAtGetUser(MapModelToData(user)) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
       Task<ErrorOr<Deleted>> deletedUserResult= _userService.DeleteUser(id);
        return deletedUserResult.Result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
    private static UserResponse MapUserResponse(HomieCore.Data.User user){
            return new UserResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.LastModifiedDateTime
            );
        }
    private CreatedAtActionResult CreatedAtGetUser(HomieCore.Data.User user)
    {
        return CreatedAtAction(
            actionName: nameof(GetUser),
            routeValues: new {id = user.Id},
            value: MapUserResponse(user)
        );
    }
    private static HomieCore.Data.User MapModelToData(HomieCore.Models.User user){
        return  new HomieCore.Data.User{
        Id=user.Id,
        FirstName=user.FirstName,
        LastName=user.LastName,
        LastModifiedDateTime=user.LastModifiedDateTime};
    }
}