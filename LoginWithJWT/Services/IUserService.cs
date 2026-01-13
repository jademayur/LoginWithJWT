using LoginWithJWT.DTOs;

namespace LoginWithJWT.Services
{
    public interface IUserService
    {
        public Task AddAsync(RegisterRequestDto request);

    }
}
