using backend.Models;

namespace backend.Services;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDTO createProjectDto);
}