using LoginWithJWT.DTOs;
using LoginWithJWT.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginWithJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _jwtTokenService;
        public AuthService(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public LoginResponseDto Login(LoginRequestDto loginRequest)
        {
            var user = new User
            {
                Id = 1,
                Email = "admin@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                Role = "Admin"

            };
           
            if(loginRequest.Email != user.Email || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var  token = _jwtTokenService.GenerateToken(user);
            return new LoginResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(30)
            };
            
        }
    }
}
