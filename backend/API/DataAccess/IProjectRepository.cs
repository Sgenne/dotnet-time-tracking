using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;

namespace API.DataAccess;

public interface IProjectRepository
{
    /// <summary>
    /// Adds a Project to persistant storage.
    /// </summary>
    /// <param name="project">The project to be stored.</param>
    /// <returns>A Result containing the outcome of the operation.</returns>
    Task<Result<Project>> AddProject(Project project);

    /// <summary>
    /// Searches for and returns the Project with the given ID.
    /// </summary>
    /// <param name="projectId">The ID of the Project to be returned.</param>
    /// <returns>An Optional that may contain a found project.</returns>
    Task<Optional<Project>> GetProjectById(int projectId);

    /// <summary>
    /// Returns all projects created by the user with the given userId.
    /// </summary>
    /// <param name="userId">The userId of the creator of the returned projects.</param>
    /// <returns>The found projects.</returns>
    Task<IEnumerable<Project>> GetProjectsByUserId(int userId);

}