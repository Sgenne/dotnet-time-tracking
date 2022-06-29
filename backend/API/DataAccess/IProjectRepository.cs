using API.Domain;
using API.Optional;
using API.Result;

namespace API.DataAccess;

public interface IProjectRepository
{
    Task<Result<Project>> AddProject(Project project);
    Task<Optional<Project>> GetProjectById(int projectId);
}