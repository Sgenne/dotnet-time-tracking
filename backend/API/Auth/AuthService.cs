using API.Auth.Dtos;
using API.Optional;
using API.Result;
using API.User;
using static API.Auth.Cryptography.PasswordHandler;

namespace API.Auth;

public class AuthService : IAuthService
{
    private const int PasswordSaltLength = 64;

    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Creates and stores a user object representing a new user.
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user to be registered.</param>
    /// <returns>A Result object containing the registered User object or an error message.</returns>
    public async Task<Result<User.User>> RegisterUser(RegisterUserDto dto)
    {
        string username = dto.Username;
        string password = dto.Password;

        Optional<User.User> existingUser = await _userRepository
            .GetUserByUsername(username);

        if (!existingUser.IsEmpty)
        {
            return Result<User.User>
                .Error(
                    $"Username \"{username}\" is not available.", Status.Forbidden
                );
        }

        byte[] passwordSalt = CreatePasswordSalt(PasswordSaltLength);
        byte[] passwordHash = ComputePasswordHash(password, passwordSalt);
        
        User.User registeredUser = await _userRepository.AddUser(new User.User
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        });

        return Result<User.User>
            .Success(registeredUser);
    }

    public Task<Result<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}