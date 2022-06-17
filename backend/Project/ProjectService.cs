using backend.Optional;
using backend.Project.Dto;
using backend.Repositories;
using backend.Result;

namespace backend.Project;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;

    public ProjectService(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto)
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