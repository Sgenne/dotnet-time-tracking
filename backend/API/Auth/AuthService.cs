using API.Auth.Dtos;
using API.Optional;
using API.Result;
using static API.Auth.Cryptography.PasswordHandler;

namespace API.Auth;

public class AuthService : IAuthService
{
    private const int PasswordSaltLength = 64;

    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Creates and stores a user object representing a new user.
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user to be registered.</param>
    /// <returns>A Result object containing the registered User object or an error message.</returns>
    public async Task<Result<User>> RegisterUser(RegisterUserDto dto)
    {
        string username = dto.Username;
        string password = dto.Password;

        Optional<User> existingUser = await _userRepository
            .GetUserByUsername(username);

        if (!existingUser.IsEmpty)
        {
            return Result<User>
                .Error(
                    $"Username \"{username}\" is not available.", Status.Forbidden
                );
        }

        byte[] passwordSalt = CreatePasswordSalt(PasswordSaltLength);
        byte[] passwordHash = ComputePasswordHash(password, passwordSalt);

        User registeredUser = await _userRepository.AddUser(new User
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        });

        return Result<User>
            .Success(registeredUser, "New user added successfully.", Status.Created);
    }

    public async Task<Result<string>> Login(string username, string password)
    {
        Optional<User> optionalUser = await _userRepository.GetUserByUsername(username);

        if (optionalUser.IsEmpty)
        {
            return Result<string>
                .Error($"No user with the username\"{username}\" was found", Status.ResourceNotFound);
        }

        User user = optionalUser.Some(u => u);
        
        // Validate password
        bool passwordIsCorrect = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);

        if (!passwordIsCorrect)
        {
            return Result<string>.Error("The given password was invalid.", Status.Unauthorized);
        }
        
        // Generate token
        return Result<string>.Error("dingus", Status.Created);

    }
}