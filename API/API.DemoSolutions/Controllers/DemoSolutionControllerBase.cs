using DS.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API.DemoSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoSolutionControllerBase : ControllerBase
    {

        protected readonly ILogger _logger;

        public DemoSolutionControllerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleUserException(Exception ex)
        {
            return BadRequest(ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleOtherException(Exception ex)
        {
            _logger.Log(LogLevel.Error, _logger?.GetType()?.FullName, ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleUnauthorizedException(Exception ex)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleForbiddenException(Exception ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ServiceResponse.ErrorResponse(ex));
        }

        protected IActionResult DuplicateRecordExistException()
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, ServiceResponse.ErrorResponse("This data already exist."));

        }

        protected IActionResult UserDefinedError()
        {
            return StatusCode(StatusCodes.Status400BadRequest, ServiceResponse.ErrorResponse("Some Error have occured."));

        }

        protected IActionResult UserDefinedErrorWithMessage(string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            return StatusCode(statusCode, ServiceResponse.ErrorResponse(message));

        }
    }
}
