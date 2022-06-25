using API.Auth.Dtos;
using API.Result;
using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        Result<User> registrationResult = await _authService.RegisterUser(registerUserDto);

        return registrationResult.Match(
            user => Created($"{HttpContext.Request.Host}/user/{user.Id}", UserDto.Of(user)),
            this.HandleErrorResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        Result<string> loginResult = await _authService.Login(loginDto);

        return loginResult.Match(
            Ok,
            this.HandleErrorResult
        );
    }
}