namespace API.Services;

public class AddActivityDto
{
    public string ActivityTitle { get; set; } = "";
    public string ActivityDescription { get; set; } = "";
    public DateTime StartDateTime { get; set; } = default;
    public DateTime EndDateTime { get; set; } = default;
    public int ProjectId { get; set; }
}