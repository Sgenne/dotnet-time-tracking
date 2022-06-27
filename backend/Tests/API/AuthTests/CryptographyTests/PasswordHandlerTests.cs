using System.Text;
using API.Utils.Cryptography;

namespace Tests.API.AuthTests.CryptographyTests;

public class PasswordHandlerTests
{
    [Fact]
    public async void VerifyPasswordTest()
    {
        string password = "password";
        byte[] passwordSalt = Encoding.UTF8.GetBytes("passwordSalt");
        byte[] hashedPassword = PasswordHandler.ComputePasswordHash(password, passwordSalt);

        bool passwordIsValid = PasswordHandler.VerifyPassword(password, passwordSalt, hashedPassword);
        
        Assert.True(passwordIsValid);
    }
}