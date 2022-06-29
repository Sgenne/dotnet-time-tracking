using System.Linq.Expressions;
using API.Domain;
using API.Optional;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Adds a User object to persistant storage. The User object is given a unique ID.
    /// </summary>
    /// <param name="user">The User object to be stored.</param>
    /// <returns>The stored User object with the unique ID added.</returns>
    public async Task<User> AddUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        
        return user;
    }

    /// <summary>
    /// Finds and returns the User object with the given ID.
    /// </summary>
    /// <param name="userId">The ID of the User object to be found.</param>
    /// <returns>An Optional with the User object if found.</returns>
    public Task<Optional<User>> GetUserById(int userId) => GetUser(u => u.Id == userId);

    /// <summary>
    /// Finds and returns the User object with the given username.
    /// </summary>
    /// <param name="username">The username of the User object to be found.</param>
    /// <returns>An Optional with the User object if found.</returns>
    public Task<Optional<User>> GetUserByUsername(string username) => GetUser(u => u.Username == username);

    private async Task<Optional<User>> GetUser(Expression<Func<User, bool>> predicate)
    {
        User? foundUser = await _dataContext
            .Users
            .FirstOrDefaultAsync(predicate);

        return foundUser == null
            ? Optional<User>.Empty()
            : Optional<User>.Of(foundUser);
    }
}