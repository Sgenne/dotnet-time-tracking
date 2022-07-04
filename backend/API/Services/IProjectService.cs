using API.Domain;
using API.Dtos.ProjectDtos;
using API.Utils.Result;

namespace API.Services;

public interface IProjectService
{
    /// <summary>
    /// Creates a new Project using the given information.
    /// </summary>
    /// <param name="createProjectDto">Contains the information used to create the new Project.</param>
    /// <returns>A Result object describing the outcome of the operation.</returns>
    Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto);

    /// <summary>
    /// Finds and returns the Project with the given ID if one exists.
    /// </summary>
    /// <param name="projectId">The ID of the Project to be returned.</param>
    Task<Result<Project>> GetProjectById(int projectId);

    /// <summary>
    /// Returns true if the user with the given userId is the owner of the project with the given projectId.
    /// Otherwise, returns false. 
    /// </summary>
    Task<bool> IsOwner(int userId, int projectId);

    /// <summary>
    /// Finds and returns the Projects created by the user with the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user whose created Projects are to be returned.</param>
    Task<IEnumerable<Project>> GetProjectsByUserId(int userId);
}