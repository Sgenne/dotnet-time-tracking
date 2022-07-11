using API.Requests.AuthRequests;
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
    [InlineData("valid", "password")]
    [InlineData("iii", "dingus")]
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
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkals",
        "1l234567890123456789012345678901212345678901234567890123456789012")]
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

    [Theory]
    [InlineData("abcde")]
    [InlineData("a¤a")]
    [InlineData("12345")]
    [InlineData("abcskjdfhk!hsdf#¤%hdf!jvkdkfkwls")]
    public void ValidateUsername_Valid(string username)
    {
        Result<string> validationResult = UserValidation.ValidateUsername(username);
        Assert.Equal(Status.Ok, validationResult.Status);
    }

    [Theory]
    [InlineData("as")]
    [InlineData(" af ")]
    [InlineData("a   a")]
    [InlineData("abcskjdfhk!hsdfkj2hdfkj  dkfk ls")]
    [InlineData("abcskjdfhkjhsdfkjshdfkjhsdkfkalsa")]
    [InlineData("     abcde     ")]
    public void ValidateUsername_Invalid(string username)
    {
        Result<string> validationResult = UserValidation.ValidateUsername(username);
        Assert.Equal(Status.BadRequest, validationResult.Status);
    }

    [Theory]
    [InlineData("passw¤rd")]
    [InlineData("12345")]
    [InlineData("!#¤%&")]
    [InlineData("2345267890123456789012345678901212345678901234567890123456789012")]
    public void ValidatePassword_Valid(string password)
    {
        Result<string> validationResult = UserValidation.ValidatePassword(password);
        Assert.Equal(Status.Ok, validationResult.Status);
    }

    [Theory]
    [InlineData("pass word")]
    [InlineData("1234")]
    [InlineData("23452678901234567890123456789012123456789012345678901234567890122")]
    public void ValidatePassword_Invalid(string password)
    {
        Result<string> validationResult = UserValidation.ValidatePassword(password);
        Assert.Equal(Status.BadRequest, validationResult.Status);
    }

    [Fact]
    public void ValidatePassword_ValidPassword_PasswordNotChanged()
    {
        string password = "password";

        Result<string> validationResult = UserValidation.ValidatePassword(password);

        string resultPassword = validationResult.Match(
            p => p,
            (_, _) => throw new Exception("Wrong handler called.")
        );

        Assert.Equal(password, resultPassword);
    }

    [Fact]
    public void ValidateUsername_UsernameIsNull()
    {
        string username = null;

        Result<string> validationResult = UserValidation.ValidateUsername(username);

        Assert.Equal(Status.BadRequest, validationResult.Status);
    }
}