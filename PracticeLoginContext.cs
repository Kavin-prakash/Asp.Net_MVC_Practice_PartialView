using Microsoft.EntityFrameworkCore;
using Practice_User_Login.Models;

namespace Practice_User_Login.Data
{
    public class PracticeLoginContext : DbContext
    {

        public PracticeLoginContext(DbContextOptions<PracticeLoginContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}