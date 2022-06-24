using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Auth;
using Microsoft.IdentityModel.Tokens;
using Xunit.Abstractions;
using TokenHandler = API.Auth.Cryptography.TokenHandler;

namespace Tests.API.AuthTests.CryptographyTests;

public class TokenHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TokenHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CreateToken()
    {
        User user = new User
        {
            Username = "username",
            PasswordHash = Encoding.UTF8.GetBytes("PasswordHash"),
            PasswordSalt = Encoding.UTF8.GetBytes("PasswordSalt"),
            Id = 10
        };

        string secret = "super secret secret. Wowsers so very much secret.";

        byte[] secretBytes = Encoding.UTF8.GetBytes(secret);

        string token = TokenHandler.CreateToken(user, secret);

        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        
        Assert.NotNull(principal);

        Claim? nameIdentifierClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        Claim? nameClaim = principal.FindFirst(c => c.Type == ClaimTypes.Name);

        if (nameIdentifierClaim == null || nameClaim == null)
        {
            throw new Exception("NameIdentifierClaim or NameClaim was null.");
        }

        Assert.Equal(nameClaim.Value, user.Username);
        Assert.Equal(nameIdentifierClaim.Value, user.Id.ToString());
    }
}