using API.DataAccess;
using API.Domain;
using API.Dtos.AuthDtos;
using API.Utils.Cryptography;
using API.Utils.Optional;
using API.Utils.Result;
using API.Validation;
using static API.Utils.Cryptography.PasswordHandler;

namespace API.Services;

public class AuthService : IAuthService
{
    private const int PasswordSaltLength = 64;

    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    /// <summary>
    /// Signs a user in by generating and returning an access token
    /// </summary>
    /// <param name="dto">The object containing the username and password of the user.</param>
    /// <returns>The created access token.</returns>
    public async Task<Result<User>> RegisterUser(RegisterUserDto dto)
    {
        string username = dto.Username;
        string password = dto.Password;

        Result<RegisterUserDto> dtoValidationResult = UserValidation.ValidateRegisterUserDto(dto);

        if (dtoValidationResult.Status != Status.Ok)
        {
            return Result<User>
                .Error(dtoValidationResult.Message, Status.BadRequest);
        }

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

        Result<User> addUserResult = await _userRepository.AddUser(new User
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        });

        return addUserResult.Match(
            u => Result<User>.Success(u, "User registered successfully.", Status.Created),
            ((_, _) => Result<User>.Error("The user could not be registered.", Status.Error))
        );
    }

    /// <summary>
    /// Validates the given username and password. If the credentials are valid, then a JWT is created and returned.
    /// </summary>
    /// <param name="dto">Contains the user information used when creating the token.</param>
    /// <returns>A Result object that contains the created token if the given credentials were valid.</returns>
    public async Task<Result<string>> Login(LoginDto dto)
    {
        string username = dto.Username;
        string password = dto.Password;

        Result<LoginDto> validationResult = UserValidation.ValidateLoginDto(dto);

        if (validationResult.Status != Status.Ok)
        {
            return Result<string>.Error(validationResult.Message, Status.Forbidden);
        }

        Optional<User> optionalUser = await _userRepository.GetUserByUsername(username);

        if (optionalUser.IsEmpty)
        {
            return Result<string>
                .Error($"No user with the username\"{username}\" was found", Status.ResourceNotFound);
        }

        User user = optionalUser.Some(u => u);
        bool passwordIsCorrect = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);

        if (!passwordIsCorrect)
        {
            return Result<string>.Error("The given password was invalid.", Status.Unauthorized);
        }

        string secret = _configuration.GetSection("AppSettings:Token").Value;
        string token = TokenHandler.CreateToken(user, secret);

        return Result<string>.Success(token);
    }
}