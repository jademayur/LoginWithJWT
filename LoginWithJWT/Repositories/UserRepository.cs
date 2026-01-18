using LoginWithJWT.Data;
using LoginWithJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginWithJWT.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //Get User by EmailId
        public async Task<User?> GetByEmailIdAsync(string emailId)
        {
            return await appDbContext.users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == emailId);
        }
        //Add User
        public async Task AddAsync(User user)
        {
           appDbContext.users.Add(user);
           await appDbContext.SaveChangesAsync();
        }

        
    }
}
