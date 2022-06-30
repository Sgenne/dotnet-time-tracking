using System.Linq.Expressions;
using API.Domain;
using API.Optional;
using API.Result;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Result<User>> AddUser(User user)
    {
        try
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return Result<User>.Success(user);
        }
        catch (DbUpdateException e)
        {
            return Result<User>.Error(e.Message, Status.Error);
        }
    }
    
    public Task<Optional<User>> GetUserById(int userId) => GetUser(u => u.Id == userId);
    
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