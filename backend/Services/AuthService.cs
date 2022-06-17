using backend.Models;
using backend.Optional;
using backend.Repositories;
using backend.Result;

namespace backend.Services;

public class AuthService
{
    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Registers a user.
    /// </summary>
    /// <param name="user">The User object of the new user.</param>
    /// <returns>A Result object containing the registered user or an error message.</returns>
    public async Task<Result<User>> RegisterUser(User user)
    {
        Optional<User> existingUser = await _userRepository
            .GetUserByUsername(user.Username);
        
        if (!existingUser.IsEmpty)
        {
            return Result<User>
                .Error(
                    $"Username \"{user.Username}\" is not available.", Status.FORBIDDEN
                );
        }

        // hash password

        User registeredUser = await _userRepository.AddUser(user);

        return Result<User>.Success(registeredUser);
    }

    public Task<Result<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}