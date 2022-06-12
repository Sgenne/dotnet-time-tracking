using backend.Models;

namespace backend.Repositories;

public class ProjectRepository
{
    private List<Project> _projects = new List<Project>();

    public async Task<Project> AddProject(Project project)
    {
        _projects.Add(project);
        return project;
    }

    public async Task<Project?> GetProjectById(int projectId)
    {
        return _projects
            .FirstOrDefault(p => p.Id == projectId);
    }
}