using API.DataAccess;
using API.Domain;
using API.Optional;
using Xunit.Abstractions;

namespace Tests.API.ProjectTests;

public class ProjectRepositoryTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ProjectRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void AddProject()
    {
        string projectTitle = "projectTitle";
        string projectDescription = "projectDescription";

        Project project = new Project
        {
            Title = projectTitle,
            Description = projectDescription
        };

        ProjectRepository projectRepository = new ProjectRepository();
        Project resultProject = await projectRepository.AddProject(project);

        Assert.Equal(projectTitle, resultProject.Title);
        Assert.Equal(projectDescription, resultProject.Description);
    }

    [Fact]
    public async void GetProjectById_NotFound()
    {
        int searchProjectId = 0;

        ProjectRepository projectRepository = new ProjectRepository();

        Optional<Project> result = await projectRepository.GetProjectById(searchProjectId);

        Assert.True(result.IsEmpty);

        result.Match(
            p => throw new Exception("Wrong handler called (SomeHandler)"),
            (() => 1));
    }

    [Fact]
    public async void GetProjectById_ProjectFound()
    {
        string projectTitle = "projectTitle";
        string projectDescription = "projectDescription";

        ProjectRepository projectRepository = new ProjectRepository();

        Project addedProject = await projectRepository.AddProject(new Project
        {
            Title = projectTitle,
            Description = projectDescription
        });

        Optional<Project> result = await projectRepository.GetProjectById(addedProject.Id);

        Project resultProject = result.Match(
            p => p,
            () => throw new Exception("Wrong handler called (ErrorHandler)")
        );
        
        Assert.Equal(resultProject.Description, projectDescription);
        Assert.Equal(resultProject.Title, projectTitle);
    }
}