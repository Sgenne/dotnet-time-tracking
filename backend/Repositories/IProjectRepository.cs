using backend.Models;
using backend.Optional;

namespace backend.Repositories;

public interface IProjectRepository
{
    Task<Project> AddProject(Project project);
    Task<Optional<Project>> GetProjectById(int projectId);
}