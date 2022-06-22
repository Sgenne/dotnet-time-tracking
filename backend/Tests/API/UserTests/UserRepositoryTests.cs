using System.Text;
using API.User;

namespace Tests.API.UserTests;

public class UserRepositoryTests
{
    [Fact]
    public async void AddUser()
    {
        string username = "username";
        byte[] passwordSalt = Encoding.UTF8.GetBytes("passwordSalt");
        byte[] passwordHash = Encoding.UTF8.GetBytes("passwordHash");

        User user = new User
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        UserRepository userRepository = new UserRepository();

        User resultUser = await userRepository.AddUser(user);

        Assert.Equal(username, resultUser.Username);
        Assert.Equal(passwordSalt, resultUser.PasswordSalt);
        Assert.Equal(passwordHash, resultUser.PasswordHash);
    }

    [Fact]
    public async void GetUserById_UserNotFound()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public async void GetUserById_UserFound()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public async void GetUserByUsername_UserNotFound()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public async void GetUserByUsername_UserFound()
    {
        throw new NotImplementedException();
    }
}