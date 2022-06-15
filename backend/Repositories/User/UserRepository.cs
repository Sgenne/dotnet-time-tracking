using backend.Optional;

namespace backend.Repositories.User;

public class UserRepository : IUserRepository
{
    public Task<Models.User> AddUser(Models.User user)
    {
        throw new NotImplementedException();
    }

    public Task<Optional<Models.User>> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }
}