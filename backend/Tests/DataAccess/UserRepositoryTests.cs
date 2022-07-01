// using System.Text;
// using API.DataAccess;
// using API.Domain;
// using API.Optional;
//
// namespace Tests.API.UserTests;
//
// public class UserRepositoryTests
// {
//     [Fact]
//     public async void AddUser()
//     {
//         User user = StubUser();
//
//         UserRepository userRepository = new UserRepository();
//
//         User resultUser = await userRepository.AddUser(user);
//
//         Assert.Equal(user.Username, resultUser.Username);
//         Assert.Equal(user.PasswordSalt, resultUser.PasswordSalt);
//         Assert.Equal(user.PasswordHash, resultUser.PasswordHash);
//     }
//
//     [Fact]
//     public async void GetUserById_UserNotFound()
//     {
//         int userId = 0;
//
//         UserRepository userRepository = new UserRepository();
//
//         Optional<User> result = await userRepository.GetUserById(userId);
//
//         result.Match(
//             p => throw new Exception("Wrong handler called (SomeHandler)"),
//             () => ""
//         );
//     }
//
//     [Fact]
//     public async void GetUserById_UserFound()
//     {
//         UserRepository userRepository = new UserRepository();
//         User existingUser = await userRepository.AddUser(StubUser());
//
//         Optional<User> result = await userRepository.GetUserById(existingUser.Id);
//
//         User resultUser = result.Match(
//             p => p,
//             () => throw new Exception("Wrong handler called (ErrorHandler).")
//         );
//
//         Assert.Equal(existingUser.Username, resultUser.Username);
//         Assert.Equal(existingUser.PasswordHash, resultUser.PasswordHash);
//         Assert.Equal(existingUser.PasswordSalt, resultUser.PasswordSalt);
//     }
//
//     [Fact]
//     public async void GetUserByUsername_UserNotFound()
//     {
//         string username = "username";
//
//         UserRepository userRepository = new UserRepository();
//
//         Optional<User> result = await userRepository.GetUserByUsername(username);
//
//         result.Match(
//             p => throw new Exception("Wrong handler called (SomeHandler)"),
//             () => ""
//         );
//     }
//
//     [Fact]
//     public async void GetUserByUsername_UserFound()
//     {
//         UserRepository userRepository = new UserRepository();
//         User existingUser = await userRepository.AddUser(StubUser());
//
//         Optional<User> result = await userRepository.GetUserByUsername(existingUser.Username);
//
//         User resultUser = result.Match(
//             p => p,
//             () => throw new Exception("Wrong handler called (ErrorHandler).")
//         );
//
//         Assert.Equal(existingUser.Username, resultUser.Username);
//         Assert.Equal(existingUser.PasswordHash, resultUser.PasswordHash);
//         Assert.Equal(existingUser.PasswordSalt, resultUser.PasswordSalt);
//     }
//
//     private User StubUser()
//     {
//         string username = "username";
//         byte[] passwordSalt = Encoding.UTF8.GetBytes("passwordSalt");
//         byte[] passwordHash = Encoding.UTF8.GetBytes("passwordHash");
//
//         return new User
//         {
//             Username = username,
//             PasswordHash = passwordHash,
//             PasswordSalt = passwordSalt
//         };
//     }
// }