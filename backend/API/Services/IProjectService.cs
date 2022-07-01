using API.Domain;
using API.Dtos.ProjectDtos;
using API.Utils.Result;

namespace API.Services;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto);
    Task<Result<Project>> GetProjectById(int projectId);
    Task<bool> IsOwner(int userId, int projectId);
}