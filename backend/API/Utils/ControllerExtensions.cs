using API.Utils.Result;
using Microsoft.AspNetCore.Mvc;

namespace API.Utils;

public static class ControllerExtensions
{
    public static IActionResult HandleErrorResult(this ControllerBase controller, string message, Status status) =>
        status switch
        {
            Status.Forbidden => new ObjectResult(message) { StatusCode = 403 },
            Status.Unauthorized => controller.Unauthorized(message),
            Status.BadRequest => controller.BadRequest(message),
            Status.ResourceNotFound => controller.NotFound(message),
            Status.Error => new ObjectResult(message) { StatusCode = 500 },
            _ => controller.Problem(message),
        };

    public static IActionResult NoUserIdResponse(this ControllerBase controller) =>
        controller.BadRequest("The access token did not contain a user id.");
}