using backend.Project.Dto;
using backend.Result;
using Microsoft.AspNetCore.Mvc;

namespace backend.Project;

[ApiController]
[Route(ROOT_URL)]
public class ProjectController : ControllerBase
{
    public const string ROOT_URL = "/project";

    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
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