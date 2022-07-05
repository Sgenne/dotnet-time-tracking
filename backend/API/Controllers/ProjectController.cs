using API.Domain;
using API.Dtos.ProjectDtos;
using API.Services;
using API.Utils;
using API.Utils.Optional;
using API.Utils.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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

    [HttpGet]
    public async Task<IActionResult> GetCreatedProjects()
    {
        Optional<int> optionalUserId = HttpContext.User.GetId();

        if (optionalUserId.IsEmpty) return this.NoUserIdResponse();

        int userId = optionalUserId.Some();

        IEnumerable<Project> userCreatedProjects = await _projectService.GetProjectsByUserId(userId);

        return Ok(userCreatedProjects);
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
        Optional<int> optionalUserId = HttpContext.User.GetId();
        if (optionalUserId.IsEmpty)
        {
            return this.NoUserIdResponse();
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