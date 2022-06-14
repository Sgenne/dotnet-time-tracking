using backend.Models;
using backend.Result;

namespace backend.Services;

public interface IAuthService
{
    Task<Result<User>> RegisterUser(User user);
    Task<Result<string>> Login(string username, string password);
}