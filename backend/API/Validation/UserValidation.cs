using API.Domain;
using API.Dtos.AuthDtos;
using API.Result;

namespace API.Validation;

public static class UserValidation
{
    public const int MinUsernameLength = 3;
    public const int MaxUsernameLength = 32;

    public const int MinPasswordLength = 5;
    public const int MaxPasswordLength = 64;

    /// <summary>
    /// Validates the content of the RegisterUserDto.
    /// </summary>
    /// <param name="dto">The dto to be validated.</param>
    /// <returns>A Result object describing the outcome of the validation. If the argument is valid, then the Result
    /// object will have status Ok. Otherwise, it will have status BadRequest.</returns>
    public static Result<RegisterUserDto> ValidateRegisterUserDto(RegisterUserDto dto)
    {
        Result<string> usernameResult = ValidateUsername(dto.Username);
        Result<string> passwordResult = ValidatePassword(dto.Password);

        if (usernameResult.Status != Status.Ok)
        {
            return Result<RegisterUserDto>.Error(usernameResult.Message, Status.BadRequest);
        }

        if (passwordResult.Status != Status.Ok)
        {
            return Result<RegisterUserDto>.Error(passwordResult.Message, Status.BadRequest);
        }

        string validUsername = usernameResult.Match(
            u => u,
            (_, _) => "");

        string validPassword = passwordResult.Match(
            p => p,
            (_, _) => ""
        );

        return Result<RegisterUserDto>.Success(new RegisterUserDto
        {
            Username = validUsername,
            Password = validPassword
        });
    }

    /// <summary>
    /// Validates the given username.
    /// </summary>
    /// <returns>A Result object describing the outcome of the validation. If the argument is valid, then the Result
    /// object will have status Ok. Otherwise, it will have status BadRequest.</returns>
    public static Result<string> ValidateUsername(string? username) =>
        ValidateField(username, MinUsernameLength, MaxUsernameLength, "username");

    /// <summary>
    /// Validates the given password.
    /// </summary>
    /// <returns>A Result object describing the outcome of the validation. If the argument is valid, then the Result
    /// object will have status Ok. Otherwise, it will have status BadRequest.</returns>
    public static Result<string> ValidatePassword(string? password) =>
        ValidateField(password, MinPasswordLength, MaxPasswordLength, "password");


    private static Result<string> ValidateField(string? value, int minLength, int maxLength, string fieldName)
    {
        if (value == null)
        {
            return Result<string>.Error($"No {fieldName} was given.", Status.BadRequest);
        }

        string trimmedValue = value.Trim();

        if (trimmedValue.Length < minLength)
        {
            return Result<string>.Error($"The {fieldName} cannot be shorter than {minLength} characters.",
                Status.BadRequest);
        }

        if (trimmedValue.Length > maxLength)
        {
            return Result<string>.Error($"The {fieldName} cannot be longer than {maxLength} characters.",
                Status.BadRequest);
        }

        return Result<string>.Success(trimmedValue);
    }
}