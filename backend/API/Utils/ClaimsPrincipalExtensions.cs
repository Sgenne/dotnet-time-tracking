using System.Security.Claims;
using API.Optional;

namespace API.Utils;

public static class ClaimsPrincipalExtensions
{
    public static Optional<int> GetId(this ClaimsPrincipal claimsPrincipal)
    {
        Claim? idClaim = claimsPrincipal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

        if (idClaim == null)
        {
            return Optional<int>.Empty();
        }

        int id = Convert.ToInt32(idClaim.Value);

        return Optional<int>.Of(id);
    }
}