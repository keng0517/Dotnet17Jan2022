using Microsoft.EntityFrameworkCore;

namespace Day19Project.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 101,
                    Name = "Super Fresh Banana",
                    Description = "Drop down any product description here.",
                    Price = 88.88,
                    Pic = "/images/Banana.jpg"
                },
                new Product()
                {
                    Id = 102,
                    Name = "Super Crunchy Biscuit",
                    Description = "Drop down any product description here.",
                    Price = 12.88,
                    Pic = "/images/Biscuit.jpg"
                },

                new Product()
                {
                    Id = 103,
                    Name = "No Brand Polo-T",
                    Description = "Drop down any product description here.",
                    Price = 23.88,
                    Pic = "/images/PoloT.jpg"
                }

                );
        }
    }
}
