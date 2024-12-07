using Microsoft.AspNetCore.Identity;

namespace P1API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
