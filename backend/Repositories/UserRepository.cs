using backend.Models;
using backend.Optional;

namespace backend.Repositories;

public class UserRepository
{
    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Optional<User>> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }
}