using backend.Optional;

namespace backend.Project;

public class ProjectRepository 
{
    private List<Project> _projects = new List<Project>();

    public async Task<Project> AddProject(Project project)
    {
        Console.WriteLine($"Project before adding: {String.Join(", ", _projects.Select(p => new { p.Title, p.Description, p.Id }).ToList())}");
        Console.WriteLine($"number of elements: {_projects.Count}");
        
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