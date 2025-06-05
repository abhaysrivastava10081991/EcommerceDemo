using Ecommerce.DataModels.Models;
using EcommerceDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUserss { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this function is used to add identity column 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Sports", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Fruits", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Vehicle", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "English Willow", Description="It is good",Price=1000,Discount=0,CategoryId=1,ImageUrl="" },
                new Product { ID = 2, Name = "Kasmiri Willow", Description = "It is good", Price = 1000, Discount = 0, CategoryId = 2, ImageUrl = "" },
                new Product { ID = 3, Name = "Meroth Willow", Description = "It is good", Price = 1000, Discount = 0, CategoryId = 2 , ImageUrl = "" }
                );
        }
    }
}

