using API.Optional;

namespace API.Project;

public interface IProjectRepository
{
    Task<Project> AddProject(Project project);
    Task<Optional<Project>> GetProjectById(int projectId);
}