using System.Collections;
using System.Security.Claims;
using API.Utils;
using API.Utils.Optional;

namespace Tests.Utils;

public class ClaimsPrincipalExtensionsTests
{
    [Fact]
    public void GetID_ClaimsPrincipalIsEmpty_EmptyOptionalReturned()
    {
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

        Optional<int> optionalId = claimsPrincipal.GetId();

        Assert.True(optionalId.IsEmpty);
    }

    [Fact]
    public void GetId_ClaimsPrincipalHasId_NonEmptyOptionalReturned()
    {
        int id = 1;
        
        IEnumerable<Claim> claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString())
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        Optional<int> optionalId = claimsPrincipal.GetId();
        
        Assert.Equal(id, optionalId.Some());
    }
}