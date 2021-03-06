using API.Domain;

namespace API.Dtos;

public class ProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public static ProjectDto Of(Project project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
    };
}