using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route(ROOT_URL)]
public class ProjectController : ControllerBase
{
    public const string ROOT_URL = "/project";

    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectDTO createProjectDto)
    {
        Result<Project> result =
            await _projectService
                .CreateProject(createProjectDto);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        string uri = $"{HttpContext.Request.Host}/{result.Data.Id}"; 
        
        return Created(uri, result.Data);
    }
}