using Microsoft.AspNetCore.Mvc;
using HomieCore.Contracts.User;

namespace HomieCore.Controllers;

[ApiController]

public class UsersController : ControllerBase
{
    [HttpPost("/users")]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        return Ok(request);
    }

     [HttpGet("/users/{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        return Ok(id);
    }
    [HttpPut("/users/{id:guid}")]
    public IActionResult UpsertUser(Guid id, UpsertUserRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/users/{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        return Ok(id);
    }
}