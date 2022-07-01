using API.Dtos.AuthDtos;
using API.Utils.Result;
using API.Validation;

namespace Tests.Validation;

public class UserValidationTests
{
    [Theory]
    [InlineData("abc", "abcde")]
    [InlineData("abc", "1234567890123456789012345678901212345678901234567890123456789012")]
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkals", "adkgk")]
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkals", "1234567890123456789012345678901212345678901234567890123456789012")]
    [InlineData("  valid   ", "password         ")]
    [InlineData(" i     i ", "dingus")]
    public void ValidateRegisterUserDto_Valid(string username, string password)
    {
        RegisterUserDto registerUserDto = new RegisterUserDto
        {
            Username = username,
            Password = password
        };

        Result<RegisterUserDto> validationResult = UserValidation.ValidateRegisterUserDto(registerUserDto);

        RegisterUserDto outputRegisterUserDto =
            validationResult.Match(d => d, (_, _) => throw new Exception("Wrong handler called."));

        string trimmedUsername = outputRegisterUserDto.Username;
        string trimmedPassword = outputRegisterUserDto.Password;

        Assert.NotEqual(' ', trimmedUsername[0]);
        Assert.NotEqual(' ', trimmedUsername[^1]);
        Assert.NotEqual(' ', trimmedPassword[0]);
        Assert.NotEqual(' ', trimmedPassword[^1]);
        Assert.Equal(Status.Ok, validationResult.Status);
    }

    [Theory]
    [InlineData("ab", "abcde")]
    [InlineData("abc", "12345267890123456789012345678901212345678901234567890123456789012")]
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkalsa", "adkgk")]
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkals", "1l234567890123456789012345678901212345678901234567890123456789012")]
    [InlineData("  ii   ", "password         ")]
    [InlineData(" i     i ", "   ding     ")]
    public void ValidateRegisterUserDto_Invalid(string username, string password)
    {
        RegisterUserDto registerUserDto = new RegisterUserDto
        {
            Username = username,
            Password = password
        };

        Result<RegisterUserDto> validationResult = UserValidation.ValidateRegisterUserDto(registerUserDto);

        Assert.Equal(Status.BadRequest, validationResult.Status);
    }

    public void ValidateUsername_Valid()
    {
        throw new NotImplementedException();
    }

    public void ValidateUsername_Invalid()
    {
        throw new NotImplementedException();
    }

    public void ValidatePassword_Valid()
    {
        throw new NotImplementedException();
    }

    public void ValidatePassword_Invalid()
    {
        throw new NotImplementedException();
    }
}