using API.Dtos.ProjectDtos;
using API.Utils.Result;

namespace API.Validation;

public static class ProjectValidation
{
    private const int MaxProjectDescriptionLength = 2048;

    private const int MinProjectTitleLength = 3;
    private const int MaxProjectTitleLength = 64;


    /// <summary>
    /// Checks that each field of the given DTO is valid.
    /// </summary>
    /// <param name="createProjectDto">The DTO to be validated.</param>
    /// <returns>A Result object describing the outcome of the validation.</returns>
    public static Result<CreateProjectDto> ValidateCreateProjectDto(CreateProjectDto createProjectDto)
    {
        string title = createProjectDto.Title;
        string description = createProjectDto.Description;
        int ownerId = createProjectDto.OwnerId;

        Result<string> titleResult = ValidateProjectTitle(title);
        Result<string> descriptionResult = ValidateProjectDescription(description);

        if (titleResult.Status != Status.Ok)
        {
            return Result<CreateProjectDto>.Error(titleResult.Message, Status.BadRequest);
        }

        if (descriptionResult.Status != Status.Ok)
        {
            return Result<CreateProjectDto>.Error(descriptionResult.Message, Status.BadRequest);
        }

        return Result<CreateProjectDto>.Success(new CreateProjectDto
        {
            Title = title,
            Description = description,
            OwnerId = ownerId
        });
    }

    /// <summary>
    /// Validates the project description.
    /// </summary>
    /// <param name="description">The description to be validated.</param>
    /// <returns>A Result object describing the outcome of the operation.</returns>
    private static Result<string> ValidateProjectDescription(string? description)
    {
        if (description == null)
        {
            return Result<string>
                .Error("No project description was given.", Status.BadRequest);
        }

        if (description.Length > MaxProjectDescriptionLength)
        {
            return Result<string>.Error(
                $"The project description may not be more than {MaxProjectDescriptionLength} characters long.",
                Status.BadRequest);
        }

        if (description.Length > 0 && description[0] == ' ')
        {
            return Result<string>
                .Error("The project description may not begin with a space.", Status.BadRequest);
        }

        if (description.Length > 0 && description[^1] == ' ')
        {
            return Result<string>
                .Error("The project description may not end with a space.", Status.BadRequest);
        }

        return Result<string>.Success(description);
    }

    /// <summary>
    /// Validates the project title.
    /// </summary>
    /// <param name="title">The title to be validated.</param>
    /// <returns>A Result object describing the outcome of the operation.</returns>
    private static Result<string> ValidateProjectTitle(string? title)
    {
        if (title == null)
        {
            return Result<string>
                .Error("No project title was given.", Status.BadRequest);
        }

        if (title.Length < MinProjectTitleLength)
        {
            return Result<string>.Error(
                $"The project title may not be less than {MinProjectTitleLength} characters long.",
                Status.BadRequest);
        }

        if (title.Length > MaxProjectTitleLength)
        {
            return Result<string>.Error(
                $"The project title may not be more than {MaxProjectTitleLength} characters long.",
                Status.BadRequest
            );
        }

        if (title[0] == ' ')
        {
            return Result<string>
                .Error("The project title may not begin with a space.", Status.BadRequest);
        }

        if (title[^1] == ' ')
        {
            return Result<string>
                .Error("The project title may not end with a space.", Status.BadRequest);
        }

        return Result<string>.Success(title);
    }
}