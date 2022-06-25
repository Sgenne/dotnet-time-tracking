namespace API.Auth.Dtos;

public class UserDto
{
    public UserDto(string username)
    {
        Username = username;
    }

    public UserDto()
    {
    }

    public string Username { get; set; }

    public static UserDto Of(User user) => new UserDto(user.Username);
}