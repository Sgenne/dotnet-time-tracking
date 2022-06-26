using System.Security.Claims;
using API.Auth;
using API.Project.Dto;
using API.Result;
using API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Project;

[ApiController]
[Authorize]
[Route(RootUrl)]
public class ProjectController : ControllerBase
{
    public const string RootUrl = "/project";

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
        // Make extension to ClaimsPrincipal to get id.
        int clientId = Convert.ToInt32(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        
        
        Result<Project> result = await _projectService.GetProjectById(projectId);

        return result.Match<IActionResult>(
            Ok,
            this.HandleErrorResult
        );
    }
}