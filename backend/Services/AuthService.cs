using backend.Models;
using backend.Optional;
using backend.Repositories;
using backend.Result;

namespace backend.Services;

public class AuthService
{

    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> RegisterUser(User user)
    {
        
        // check username not occupied
        
        User registeredUser = await _userRepository.AddUser(user);
        
        
        
    }

    public Task<Result<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}