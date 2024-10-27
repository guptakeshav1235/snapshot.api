using Microsoft.AspNetCore.Identity;

namespace snapShot.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
