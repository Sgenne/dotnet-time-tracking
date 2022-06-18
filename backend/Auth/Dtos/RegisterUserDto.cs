namespace backend.Auth.Dtos;

public class RegisterUserDto
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}