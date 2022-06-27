using API.Domain;
using API.Optional;

namespace API.DataAccess;

public interface IProjectRepository
{
    Task<Project> AddProject(Project project);
    Task<Optional<Project>> GetProjectById(int projectId);
}