using System.Collections.ObjectModel;
using API.Domain;
using API.Dtos;
using API.Requests.ProjectRequests;
using API.Utils.Result;

namespace API.Services;

public interface IProjectService
{
    /// <summary>
    /// Creates a new Project using the given information.
    /// </summary>
    /// <param name="createProjectDto">Contains the information used to create the new Project.</param>
    /// <returns>A Result object describing the outcome of the operation.</returns>
    Task<Result<ProjectDto>> CreateProject(CreateProjectDto createProjectDto, int ownerId);

    /// <summary>
    /// Finds and returns the Project with the given ID if one exists.
    /// </summary>
    /// <param name="projectId">The ID of the Project to be returned.</param>
    Task<Result<ProjectDto>> GetProjectById(int projectId);

    /// <summary>
    /// Returns true if the user with the given userId is the owner of the project with the given projectId.
    /// Otherwise, returns false. 
    /// </summary>
    Task<bool> IsOwner(int userId, int projectId);

    /// <summary>
    /// Finds and returns the Projects created by the user with the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user whose created Projects are to be returned.</param>
    Task<Collection<ProjectDto>> GetProjectsByUserId(int userId);

    /// <summary>
    /// Creates and adds a recorded activity to a project.  
    /// </summary>
    /// <returns>The activity that was added.</returns>
    Task<Result<Activity>> AddActivity(AddActivityDto addActivityDto);
}