using backend.Models;
using backend.Result;

namespace backend.Services;

public class AuthService : IAuthService
{
    public Task<Result<User>> RegisterUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}