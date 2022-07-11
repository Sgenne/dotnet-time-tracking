using API.DataAccess;
using API.Domain;
using API.Dtos;
using API.Requests.AuthRequests;
using API.Services;
using API.Utils.Optional;
using API.Utils.Result;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Tests.Services;

public class AuthServiceTests
{
    [Fact]
    public async void RegisterUser_UsernameOccupied()
    {
        string username = "username";
        string password = "password";

        RegisterUserDto registerUserDto = new RegisterUserDto
        {
            Username = username,
            Password = password
        };

        Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
        Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();

        mockRepository
            .Setup(m => m.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync((string str) => Optional<User>.Of(new User
                {
                    Username = str
                })
            );
        AuthService authService = new AuthService(mockRepository.Object, mockConfiguration.Object);

        Result<UserDto> result = await authService.RegisterUser(registerUserDto);

        result.Match(
            u => throw new Exception("Wrong handler called"),
            (s, status) => s
        );

        Assert.Equal(Status.Forbidden, result.Status);
    }

    [Fact]
    public async void RegisterUser_UsernameAvailable()
    {
        string username = "username";
        string password = "password";

        RegisterUserDto registerUserDto = new RegisterUserDto
        {
            Username = username,
            Password = password
        };

        Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
        Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();

        mockRepository
            .Setup(m => m.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync((string str) => Optional<User>.Empty()
            );

        mockRepository
            .Setup(m => m.AddUser(It.IsAny<User>()))
            .ReturnsAsync((User u) =>
            {
                u.Id = 1;
                return Result<User>
                    .Success(u);
            });

        AuthService authService = new AuthService(mockRepository.Object, mockConfiguration.Object);

        Result<UserDto> result = await authService.RegisterUser(registerUserDto);

        UserDto registeredUser = result.Match(
            (p) => p,
            (message, status) => throw new Exception("Wrong handler called")
        );

        Assert.Equal(Status.Created, result.Status);
        Assert.Equal(registeredUser.Username, username);
    }
}