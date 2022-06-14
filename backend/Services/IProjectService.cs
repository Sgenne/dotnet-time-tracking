using backend.Models;
using backend.Result;

namespace backend.Services;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDTO createProjectDto);
    Task<Result<Project>> GetProjectById(int projectId);
}