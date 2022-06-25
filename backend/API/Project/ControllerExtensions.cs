using API.Project.Dto;
using API.Result;
using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Project;

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
    public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
    {
        Result<Project> result =
            await _projectService
                .CreateProject(createProjectDto);

        return result.Match<IActionResult>(
            project => Created($"{HttpContext.Request.Host}/project/{project.Id}", project),
            this.HandleErrorResult);
    }

    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectById(int projectId)
    {
        Result<Project> result = await _projectService.GetProjectById(projectId);

        return result.Match<IActionResult>(
            Ok,
            this.HandleErrorResult
        );
    }
}