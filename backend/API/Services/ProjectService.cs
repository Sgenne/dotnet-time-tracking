using API.DataAccess;
using API.Domain;
using API.Dtos.ProjectDtos;
using API.Optional;
using API.Result;

namespace API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto)
    {
        //TODO - Validation

        Result<Project> resultProject = await _projectRepository
            .AddProject(
                new Project
                {
                    Description = createProjectDto.Description,
                    Title = createProjectDto.Title,
                    UserId = createProjectDto.OwnerId,
                });

        return resultProject.Match(
            p => Result<Project>.Success(p, "The project was created successfully.", Status.Created),
            (s, status) => Result<Project>.Error("The project could not be created.", Status.Error)
        );
    }

    public async Task<Result<Project>> GetProjectById(int projectId)
    {
        Optional<Project> foundProject = await _projectRepository
            .GetProjectById(projectId);

        Result<Project> NoneHandler() =>
            Result<Project>.Error($"No project with id {projectId} was found", Status.ResourceNotFound);

        return foundProject.Match(Result<Project>.Success, NoneHandler);
    }

    public async Task<bool> IsOwner(int userId, int projectId)
    {
        Console.WriteLine("userId: " + userId);
        Console.WriteLine("projectId: " + projectId);
        Optional<Project> optionalProject = await _projectRepository.GetProjectById(projectId);


        return optionalProject.Match(
            p =>
            {
                Console.WriteLine("HERE");
                Console.WriteLine("p.UserId: " + p.UserId);
                return p.UserId == userId;
            },
            () => false
        );
    }
}