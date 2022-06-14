using backend.DTOs;
using backend.Models;
using backend.Result;

namespace backend.Services;

public interface IProjectService
{
    Task<Result<Project>> CreateProject(CreateProjectDto createProjectDto);
    Task<Result<Project>> GetProjectById(int projectId);
}