using Microsoft.AspNetCore.Mvc;
namespace HomieCore.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}