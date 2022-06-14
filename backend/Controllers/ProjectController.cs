using backend.Models;
using backend.Result;
using backend.Services;
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

        return result.Match(
            project => Created($"{HttpContext.Request.Host}/{project.Id}", project),
            (message, status) => Problem(message));
    }

    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectById(int projectId)
    {
        Result<Project> result = await _projectService.GetProjectById(projectId);

        return result.Match<IActionResult>(
            Ok,
            (message, status) => NotFound(message)
        );
    }
}