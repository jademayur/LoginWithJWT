using LoginWithJWT.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace LoginWithJWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }
    }
}
