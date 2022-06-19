using API.Optional;

namespace API.Project;

public class ProjectRepository 
{
    private List<API.Project.Project> _projects = new List<API.Project.Project>();

    public async Task<API.Project.Project> AddProject(API.Project.Project project)
    {
        Console.WriteLine($"Project before adding: {String.Join(", ", _projects.Select(p => new { p.Title, p.Description, p.Id }).ToList())}");
        Console.WriteLine($"number of elements: {_projects.Count}");
        
        project.Id = _projects.Count;

        _projects.Add(project);
        return project;
    }

    public async Task<Optional<API.Project.Project>> GetProjectById(int projectId)
    {
        API.Project.Project? foundProject = _projects
            .FirstOrDefault(p => p.Id == projectId);

        if (foundProject == null)
        {
            return Optional<API.Project.Project>.Empty();
        }

        return Optional<API.Project.Project>
            .Of(foundProject);
    }
}