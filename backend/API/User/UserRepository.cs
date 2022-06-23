using API.Optional;

namespace API.User;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public async Task<User> AddUser(User user)
    {
        user.Id = _users.Count;
        _users.Add(user);
        return user;
    }

    public Task<Optional<User>> GetUserById(int userId) => GetUser(u => u.Id == userId);

    public Task<Optional<User>> GetUserByUsername(string username) => GetUser(u => u.Username == username);

    private async Task<Optional<User>> GetUser(Func<User, bool> predicate)
    {
        User? foundUser = _users
            .FirstOrDefault(predicate);

        return foundUser == null
            ? Optional<User>.Empty()
            : Optional<User>.Of(foundUser);
    }
}