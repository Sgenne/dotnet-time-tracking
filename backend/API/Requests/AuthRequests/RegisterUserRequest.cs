namespace API.Requests.AuthRequests;

public class RegisterUserDto
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}