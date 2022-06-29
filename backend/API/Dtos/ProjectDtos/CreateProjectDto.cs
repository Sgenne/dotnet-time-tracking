namespace API.Dtos.ProjectDtos;

public class CreateProjectDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int OwnerId { get; set; }
}