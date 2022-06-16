using backend.Models;
using backend.Optional;

namespace backend.Repositories;

public class UserRepository
{
    private readonly List<User> _users = new();

    public async Task<User> AddUser(User user)
    {
        user.Id = _users.Count;
        _users.Add(user);
        return user;
    }

    public async Task<Optional<User>> GetUserById(int userId)
    {
        User? foundUser = _users
            .FirstOrDefault(u => u.Id == userId);

        return foundUser == null 
            ? Optional<User>.Empty() 
            : Optional<User>.Of(foundUser);
    }
}