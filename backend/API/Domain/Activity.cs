namespace API.Domain;

public class Activity
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime StartDateTime { get; set; } = default;
    public DateTime EndDateTime { get; set; } = default;
    public int ProjectId { get; set; }
}