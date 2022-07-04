using API.DataAccess;
using API.Domain;
using API.Dtos.ProjectDtos;
using API.Utils.Optional;
using API.Utils.Result;
using API.Validation;

namespace API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    /// <summary>
    /// Creates a new Project using the given information.
    /// </summary>
    /// <param name="createProjectDto">Contains the information used to create the new Project.</param>
    /// <returns>A Result object describing the outcome of the operation.</returns>
    public async Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto)
    {
        Result<CreateProjectDto> validationResult = ProjectValidation
            .ValidateCreateProjectDto(createProjectDto);

        if (validationResult.Status != Status.Ok)
        {
            return Result<Project>.Error(validationResult.Message, Status.BadRequest);
        }

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

    /// <summary>
    /// Finds and returns the Project with the given ID if one exists.
    /// </summary>
    /// <param name="projectId">The ID of the Project to be returned.</param>
    public async Task<Result<Project>> GetProjectById(int projectId)
    {
        Optional<Project> foundProject = await _projectRepository
            .GetProjectById(projectId);

        Result<Project> NoneHandler() =>
            Result<Project>.Error($"No project with id {projectId} was found", Status.ResourceNotFound);

        return foundProject.Match(Result<Project>.Success, NoneHandler);
    }

    /// <summary>
    /// Returns true if the user with the given userId is the owner of the project with the given projectId.
    /// Otherwise, returns false. 
    /// </summary>
    public async Task<bool> IsOwner(int userId, int projectId)
    {
        Optional<Project> optionalProject = await _projectRepository.GetProjectById(projectId);

        return optionalProject.Match(
            p => p.UserId == userId,
            () => false
        );
    }

    /// <summary>
    /// Finds and returns the Projects created by the user with the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user whose created Projects are to be returned.</param>
    public Task<IEnumerable<Project>> GetProjectsByUserId(int userId) => 
        _projectRepository.GetProjectsByUserId(userId);
}