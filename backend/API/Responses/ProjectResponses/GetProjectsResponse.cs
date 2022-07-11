using System.Collections.ObjectModel;
using API.Dtos;

namespace API.Responses.ProjectResponses;

public class GetProjectsResponse
{
    public Collection<ProjectDto> projects { get; set; } 
}