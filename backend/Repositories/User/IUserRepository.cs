using backend.Optional;

namespace backend.Repositories.User;

public interface IUserRepository
{
    Task<Models.User> AddUser(Models.User user);
    Task<Optional<Models.User>> GetUserById(int userId);
}