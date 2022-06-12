using backend.Models;
using backend.Repositories;

namespace backend.Services;

public class ProjectService : IProjectService
{
    private readonly ProjectRepository _projectRepository;

    public ProjectService(ProjectRepository projectRepository)
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

        return new Result<Project>
        {
            Data = storedProject
        };
    }
}