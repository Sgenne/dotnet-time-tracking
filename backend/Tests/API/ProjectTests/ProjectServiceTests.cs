using API.DataAccess;
using API.Domain;
using API.Dtos.ProjectDtos;
using API.Optional;
using API.Result;
using API.Services;
using Moq;

namespace Tests.API.ProjectTests;

public class ProjectServiceTests
{
    [Fact]
    public async void CreateProject()
    {
        Mock<IProjectRepository> mockRepository = new Mock<IProjectRepository>();

        int newProjectId = 1;
        mockRepository
            .Setup(m => m.AddProject(It.IsAny<Project>()))
            .ReturnsAsync((Project p) =>
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

        mockRepository
            .Verify(
                m => m.AddProject(It.IsAny<Project>()),
                Times.Once
            );

        Assert.Equal(Status.Created, result.Status);
        Assert.Equal(createProjectDto.Title, resultProject.Title);
        Assert.Equal(createProjectDto.Description, resultProject.Description);
        Assert.Equal(newProjectId, resultProject.Id);
    }

    [Fact]
    public async void GetProjectById_ProjectNotFound()
    {
        Mock<IProjectRepository> mockProjectRepository = new Mock<IProjectRepository>();

        mockProjectRepository
            .Setup(m => m.GetProjectById(It.IsAny<int>()))
            .ReturnsAsync(Optional<Project>.Empty());

        ProjectService projectService = new ProjectService(mockProjectRepository.Object);

        int searchId = 1;

        Result<Project> result = await projectService.GetProjectById(searchId);

        mockProjectRepository.Verify(
            m => m.GetProjectById(searchId),
            Times.Once
        );

        result.Match(
            (p) => throw new Exception("SuccessHandler called."),
            ((s, status) => 1)
        );

        Assert.Equal(Status.ResourceNotFound, result.Status);
    }
}