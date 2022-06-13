using backend.Models;
using backend.Services.Result;

namespace backend.Services;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDTO createProjectDto);
}