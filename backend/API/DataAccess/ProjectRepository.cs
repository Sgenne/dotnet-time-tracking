using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess;

public class ProjectRepository : IProjectRepository
{
    private readonly DataContext _dataContext;

    public ProjectRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Adds the given Project to persistant storage. The stored project is given a unique ID.
    /// </summary>
    /// <param name="project">The Project to be stored.</param>
    /// <returns>A Result object with the outcome of the operation.</returns>
    public async Task<Result<Project>> AddProject(Project project)
    {
        try
        {
            await _dataContext.Projects.AddAsync(project);
            await _dataContext.SaveChangesAsync();
            return Result<Project>.Success(project, "Project stored.", Status.Created);
        }
        catch (DbUpdateException e)
        {
            return Result<Project>.Error(e.Message, Status.Error);
        }
    }


    /// <summary>
    /// Returns the Project with the given ID.
    /// </summary>
    /// <param name="projectId">The ID of the project to be returned.</param>
    public async Task<Optional<Project>> GetProjectById(int projectId)
    {
        Project? foundProject = await _dataContext.Projects
            .FirstOrDefaultAsync(p => p.Id == projectId);

        Console.WriteLine("foundProject: " + foundProject);
        
        if (foundProject == null)
        {
            return Optional<Project>.Empty();
        }

        return Optional<Project>
            .Of(foundProject);
    }
}