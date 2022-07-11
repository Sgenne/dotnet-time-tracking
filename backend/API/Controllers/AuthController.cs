using API.Domain;
using API.Dtos;
using API.Requests.AuthRequests;
using API.Responses.AuthResponses;
using API.Services;
using API.Utils;
using API.Utils.Result;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
        Result<UserDto> registrationResult = await _authService.RegisterUser(registerUserDto);

        return registrationResult.Match(
            user => Created($"{HttpContext.Request.Host}/auth/{user.Id}", user),
            this.HandleErrorResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        Result<LoginResponse> loginResult = await _authService.Login(loginDto);

        return loginResult.Match(
            Ok,
            this.HandleErrorResult
        );
    }
}