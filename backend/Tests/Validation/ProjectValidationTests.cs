using API.Requests.ProjectRequests;
using API.Utils.Result;
using API.Validation;

namespace Tests.Validation;

public class ProjectValidationTests
{
    [Theory]
    [InlineData("title", "description", 0)]
    [InlineData("abc", "", -1)]
    [InlineData("8I8063ply5x72q5u#Q1VB1OfbsNufMC506m0lhE44IneN8mXhF7VBNMrwoiT1YnV", "", int.MaxValue)]
    public void ValidateCreateProjectDto_dtoIsValid_SuccessResult(string title, string description, int ownerId)
    {
        CreateProjectDto createProjectDto = new CreateProjectDto
        {
            Title = title,
            Description = description,
            OwnerId = ownerId
        };

        Result<CreateProjectDto> validationResult = ProjectValidation.ValidateCreateProjectDto(createProjectDto);

        Assert.Equal(Status.Ok, validationResult.Status);
    }

    [Theory]
    [InlineData("", "description", 0)]
    [InlineData("ab", "", -1)]
    [InlineData("8I8063plys5x72q5ufQ1VB1OfbsNufMC506m0lhE44IneN8mXhF7VBNMrwoiT1YnV", "", int.MaxValue)]
    [InlineData(null, "", 1)]
    [InlineData("abc", null, 1)]
    [InlineData(" abc", "", 2)]
    [InlineData("abc ", "", 2)]
    [InlineData("abc", " desc", 2)]
    [InlineData("abc", "desc ", 2)]
    public void ValidateCreateProjectDto_dtoIsInvalid_ErrorResult(string title, string description, int ownerId)
    {
        CreateProjectDto createProjectDto = new CreateProjectDto
        {
            Title = title,
            Description = description,
            OwnerId = ownerId
        };

        Result<CreateProjectDto> validationResult = ProjectValidation.ValidateCreateProjectDto(createProjectDto);

        Assert.Equal(Status.BadRequest, validationResult.Status);
    }
}