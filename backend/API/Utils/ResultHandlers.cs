using API.Result;
using Microsoft.AspNetCore.Mvc;

namespace API.Utils;

public static class ControllerExtensions
{

    public static IActionResult HandleErrorResult(this ControllerBase controller, string message, Status status) =>
        status switch
        {
            Status.Forbidden => controller.Forbid(message),
            Status.Unauthorized => controller.Unauthorized(message),
            Status.BadRequest => controller.BadRequest(message),
            Status.ResourceNotFound => controller.NotFound(message),
            _ => controller.Problem(message),
        };
}