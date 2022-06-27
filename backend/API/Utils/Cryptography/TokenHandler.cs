using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Domain;
using Microsoft.IdentityModel.Tokens;

namespace API.Utils.Cryptography;

public static class TokenHandler
{
    
    /// <summary>
    /// Creates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The User object used when creating the token.</param>
    /// <param name="secret">The secret used when creating the token</param>
    /// <returns>The created token.</returns>
    public static string CreateToken(User user, string secret)
    {
        List <Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = signingCredentials
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}