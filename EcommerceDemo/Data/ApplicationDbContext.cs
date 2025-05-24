using EcommerceDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Sports", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Fruits", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Vehicle", DisplayOrder = 3 }
                );
        }
    }
}

