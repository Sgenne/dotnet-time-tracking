using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("project")]
public class ProjectController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject()
    {
           
    }
}