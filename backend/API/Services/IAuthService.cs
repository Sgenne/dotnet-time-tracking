using API.Domain;
using API.Dtos.AuthDtos;
using API.Utils.Result;

namespace API.Services;

public interface IAuthService
{
    /// <summary>
    /// Creates and stores a user object representing a new user.
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user to be registered.</param>
    /// <returns>A Result object containing the registered User object or an error message.</returns>
    Task<Result<User>> RegisterUser(RegisterUserDto dto);

    /// <summary>
    /// Signs a user in by generating and returning an access token
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user.</param>
    /// <returns>The created access token.</returns>
    Task<Result<string>> Login(LoginDto dto);
}