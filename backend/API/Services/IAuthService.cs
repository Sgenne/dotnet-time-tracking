using API.Domain;
using API.Dtos.AuthDtos;
using API.Result;

namespace API.Services;

public interface IAuthService
{
    /// <summary>
    /// Creates and stores a user object representing a new user.
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user to be registered.</param>
    /// <returns>A Result object containing the registered User object or an error message.</returns>
    Task<Result<User>> RegisterUser(RegisterUserDto dto);

    Task<Result<string>> Login(LoginDto loginDto);
}