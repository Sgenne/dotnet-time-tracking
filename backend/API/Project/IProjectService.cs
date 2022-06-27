using API.Project.Dto;
using API.Result;

namespace API.Project;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto);
    Task<Result<Project>> GetProjectById(int projectId);
    Task<bool> IsOwner(int userId, int projectId);
}