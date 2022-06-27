using System.Security.Claims;
using API.Auth;
using API.Optional;
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
        
        // Add user id
        
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
        Optional<int> optionalUserId = HttpContext.User.GetId();
        if (optionalUserId.IsEmpty)
        {
            return BadRequest("The access token did not contain a user id.");
        }

        int userId = optionalUserId.Some();

        bool isOwner = await _projectService.IsOwner(userId, projectId);

        if (!isOwner)
        {
            return new ObjectResult("The user id does not match the owner of the specified project.")
                { StatusCode = 403 };
        }

        Result<Project> result = await _projectService.GetProjectById(projectId);

        return result.Match<IActionResult>(
            Ok,
            this.HandleErrorResult
        );
    }
}