using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    user_id = 101,
                    user_name = "Raindy Keng",
                    user_password = "123123Aa@",
                    user_email = "raindy@email.com"
                },
                new User()
                {
                    user_id = 102,
                    user_name = "Jane Wong",
                    user_password = "123123Aa@",
                    user_email = "jane123123@email.com"
                },
                new User()
                {
                    user_id = 103,
                    user_name = "Jupiter Leong",
                    user_password = "123123Aa@",
                    user_email = "jupiterleong@email.com"
                }
            );
        }
    }
}
