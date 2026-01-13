using LoginWithJWT.Models;

namespace LoginWithJWT.Services
{
    public interface IJwtTokenService
    {
       public string GenerateToken(User user);
    }
}
