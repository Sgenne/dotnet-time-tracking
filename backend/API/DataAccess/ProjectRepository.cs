using API.Domain;
using API.Optional;

namespace API.DataAccess;

public class ProjectRepository : IProjectRepository
{
    private List<Project> _projects = new List<Project>();

    public async Task<Project> AddProject(Project project)
    {
        project.Id = _projects.Count;

        _projects.Add(project);
        return project;
    }

    public async Task<Optional<Project>> GetProjectById(int projectId)
    {
        Project? foundProject = _projects
            .FirstOrDefault(p => p.Id == projectId);

        if (foundProject == null)
        {
            return Optional<Project>.Empty();
        }

        return Optional<Project>
            .Of(foundProject);
    }
}