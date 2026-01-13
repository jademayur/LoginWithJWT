using LoginWithJWT.Models;

namespace LoginWithJWT.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetByEmailIdAsync(string emailId);

        public Task AddAsync(User user);
    }
}
