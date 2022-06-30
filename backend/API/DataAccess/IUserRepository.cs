using API.Domain;
using API.Optional;
using API.Result;

namespace API.DataAccess;

public interface IUserRepository
{
    /// <summary>
    /// Adds a User object to persistant storage. The User object is given a unique ID.
    /// </summary>
    /// <param name="user">The User object to be stored.</param>
    /// <returns>The stored User object with the unique ID added.</returns>
    Task<Result<User>> AddUser(User user);

    /// <summary>
    /// Finds and returns the User object with the given ID.
    /// </summary>
    /// <param name="userId">The ID of the User object to be found.</param>
    /// <returns>An Optional with the User object if found.</returns>
    Task<Optional<User>> GetUserById(int userId);

    /// <summary>
    /// Finds and returns the User object with the given username.
    /// </summary>
    /// <param name="username">The username of the User object to be found.</param>
    /// <returns>An Optional with the User object if found.</returns>
    Task<Optional<User>> GetUserByUsername(string username);
}