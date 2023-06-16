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
        ErrorOr<User> requestToUserResult = HomieCore.Models.User.From(request);

        if (requestToUserResult.IsError)
        {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        ErrorOr<Created> createUserResult = _userService.CreateUser(user);

        return createUserResult.Match(
            created => CreatedAtGetUser(user),
            errors => Problem(errors));
    }
     [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        ErrorOr<User> getUserResult = _userService.GetUser(id);
        return getUserResult.Match(
            user => Ok(MapUserResponse(user)),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertUser(Guid id, UpsertUserRequest request)
    {
        ErrorOr<User> requestToUserResult = HomieCore.Models.User.From( id, request);
        if (requestToUserResult.IsError){
            return Problem(requestToUserResult.Errors);
        }
        var user = requestToUserResult.Value;
        ErrorOr<UpsertedUser> upsertedUserResult = _userService.UpsertUser(user);
        return upsertedUserResult.Match(
            upserted => upserted.IsNewUser ? CreatedAtGetUser(user) : NoContent(),
            errors => Problem (errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        ErrorOr<Deleted> deletedUserResult= _userService.DeleteUser(id);
        return deletedUserResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
    private static UserResponse MapUserResponse(User user){
            return new UserResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.LastModifiedDateTime,
                user.Groups
            );
        }
    private CreatedAtActionResult CreatedAtGetUser(User user)
    {
        return CreatedAtAction(
            actionName: nameof(GetUser),
            routeValues: new {id = user.Id},
            value: MapUserResponse(user)
        );
    }
}