using API.DataAccess;
using API.Domain;
using API.Dtos;
using API.Requests.ProjectRequests;
using API.Services;
using API.Utils.Optional;
using API.Utils.Result;
using Moq;

namespace Tests.Services;

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
                return Result<Project>.Success(p);
            });


        ProjectService projectService = new ProjectService(mockRepository.Object);

        CreateProjectDto createProjectDto = new CreateProjectDto
        {
            Title = "title",
            Description = "Description"
        };

        Result<ProjectDto> result = await projectService.CreateProject(createProjectDto, 1);
        ProjectDto resultProject = result
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

        Result<ProjectDto> result = await projectService.GetProjectById(searchId);

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