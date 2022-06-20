using API.Project;
using API.Project.Dto;
using API.Result;
using Moq;

namespace Tests.API.ProjectTests;

public class ProjectServiceTests
{
    [Fact]
    public async void CreateProject()
    {
        var mockRepository = new Mock<IProjectRepository>();

        int newProjectId = 1;
        mockRepository
            .Setup(m => m.AddProject(It.IsAny<Project>()))
            .Returns(async (Project p) =>
            {
                p.Id = newProjectId;
                return p;
            });

        ProjectService projectService = new ProjectService(mockRepository.Object);

        CreateProjectDto createProjectDto = new CreateProjectDto
        {
            Title = "title",
            Description = "Description"
        };

        Result<Project> result = await projectService.CreateProject(createProjectDto);
        Project resultProject = result
            .Match(
                p => p,
                (_, __) => throw new Exception("ErrorHandler called.")
            );


        Assert.Equal(Status.Created, result.Status);
        Assert.Equal(createProjectDto.Title, resultProject.Title);
        Assert.Equal(createProjectDto.Description, resultProject.Description);
        Assert.Equal(newProjectId, resultProject.Id);
    }
}