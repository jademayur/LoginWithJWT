using LoginWithJWT.DTOs;
using LoginWithJWT.Models;
using LoginWithJWT.Repositories;
using Microsoft.AspNetCore.Identity;

namespace LoginWithJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;
        public AuthService(IJwtTokenService jwtTokenService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public LoginResponseDto Login(LoginRequestDto loginRequest)
        {
            var user = _userRepository.GetByEmailIdAsync(loginRequest.Email).Result;

                    
            if(user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
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
