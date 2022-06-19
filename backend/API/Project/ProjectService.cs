using API.Optional;
using API.Project.Dto;
using API.Result;

namespace API.Project;

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
            Result<Project>.Error($"No project with id {projectId} was found", Status.ResourceNotFound);

        return foundProject.Match(Result<Project>.Success, NoneHandler);
    }
}