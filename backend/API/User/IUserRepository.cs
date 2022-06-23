using API.Optional;

namespace API.User;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task<Optional<User>> GetUserById(int userId);
    Task<Optional<User>> GetUserByUsername(string username);
}