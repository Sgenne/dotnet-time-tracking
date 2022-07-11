using API.Domain;
using API.Dtos;
using API.Requests.AuthRequests;
using API.Responses.AuthResponses;
using API.Utils.Result;

namespace API.Services;

public interface IAuthService
{
    /// <summary>
    /// Creates and stores a user object representing a new user.
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user to be registered.</param>
    /// <returns>A Result object containing the registered User object or an error message.</returns>
    Task<Result<UserDto>> RegisterUser(RegisterUserDto dto);

    /// <summary>
    /// Signs a user in by generating and returning an access token
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user.</param>
    /// <returns>The created access token.</returns>
    Task<Result<LoginResponse>> Login(LoginDto dto);
}