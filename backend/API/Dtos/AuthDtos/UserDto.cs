using API.Domain;

namespace API.Dtos.AuthDtos;

public class UserDto
{
    public UserDto(string username, int id)
    {
        Username = username;
        Id = id;
    }

    public UserDto()
    {
    }

    public string Username { get; set; }
    public int Id { get; set; }
    
    public static UserDto Of(User user) => new UserDto(user.Username, user.Id);
}