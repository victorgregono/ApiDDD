using Microsoft.AspNetCore.Mvc;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.ViewModels;
using System.Linq;
using System.Net;
using System.Text.Json;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ApiDDD.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(OperationResult result)
        {
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            //var userId = Convert.ToInt64(User.FindFirst("idUser")?.Value);

            if (!result.IsValid)
            {
                var responseError = ErrorResponse(result);

                return responseError;
            }

            return Ok(result.Content ?? string.Empty);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(MapErrorsToResponse(result.Result));

                case HttpStatusCode.NotFound:
                    return NotFound(MapErrorsToResponse(result.Result));

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(MapErrorsToResponse(result.Result));

                default:
                    return BadRequest(MapErrorsToResponse(result.Result));
            }
        }

        private static ErrorViewModel MapErrorsToResponse(ValidationResult validationResult)
            => new ErrorViewModel(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
    }
}