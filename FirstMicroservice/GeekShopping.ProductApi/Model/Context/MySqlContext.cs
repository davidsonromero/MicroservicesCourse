using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() {}
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product { 
                Id = 5,
                Name = "Name",
                Price = (decimal)99.9,
                Description = "Description",
                CategoryName = "Category",
                ImageUrl = "Teste"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Name",
                Price = (decimal)99.9,
                Description = "Description",
                CategoryName = "Category",
                ImageUrl = "Teste"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Name",
                Price = (decimal)99.9,
                Description = "Description",
                CategoryName = "Category",
                ImageUrl = "Teste"
            });
        }
    }
}
