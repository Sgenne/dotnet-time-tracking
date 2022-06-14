using backend.Models;
using backend.Optional;
using backend.Repositories;
using backend.Result;

namespace backend.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<Project>> CreateProject(CreateProjectDTO createProjectDto)
    {
        Project storedProject = await _projectRepository
            .AddProject(
                new Project
                {
                    Description = createProjectDto.Description,
                    Title = createProjectDto.Title
                });

        return Result<Project>
            .Success(storedProject);
    }

    public async Task<Result<Project>> GetProjectById(int projectId)
    {
        Optional<Project> foundProject = await _projectRepository
            .GetProjectById(projectId);

        Result<Project> NoneHandler() =>
            Result<Project>.Error($"No project with id {projectId} was found", Status.RESOURCE_NOT_FOUND);

        return foundProject.Match(Result<Project>.Success, NoneHandler);
    }
}