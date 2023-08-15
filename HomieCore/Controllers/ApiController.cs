using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace HomieCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.All(e => e.Type == ErrorType.Validation))
            {
                var modelStateDictionary = new ModelStateDictionary();

                foreach (var error in errors)
                {
                    modelStateDictionary.AddModelError(error.Code, error.Description);
                }

                return BadRequest(new 
                {
                    status = StatusCodes.Status400BadRequest,
                    errors = modelStateDictionary.SelectMany(kvp => kvp.Value.Errors.Select(e => new { key = kvp.Key, error = e.ErrorMessage }))
                });
            }

            if (errors.Any(e => e.Type == ErrorType.Unexpected))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new 
                {
                    status = StatusCodes.Status500InternalServerError,
                    errors = errors.Select(e => new { code = e.Code, description = e.Description })
                });
            }

            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            return StatusCode(statusCode, new 
            {
                status = statusCode,
                errors = errors.Select(e => new { code = e.Code, description = e.Description })
            });
        }
    }
}
