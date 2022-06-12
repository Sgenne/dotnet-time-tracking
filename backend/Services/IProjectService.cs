using backend.Models;

namespace backend.Services;

public interface IProjectService
{
    Task<ServiceResult<Project>> CreateProject(CreateProjectDTO createProjectDto);
}