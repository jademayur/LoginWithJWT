using LoginWithJWT.DTOs;

namespace LoginWithJWT.Services
{
    public interface IAuthService
    {
       
        LoginResponseDto Login(LoginRequestDto loginRequest);
    }
}
