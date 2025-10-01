using GreatShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreatShop.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var basicProducts = new List<Product>
            {
                new Product { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Товар 1", Cost = 100.50m, Description = "Описание товара 1" },
                new Product { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Товар 2", Cost = 200.75m, Description = "Описание товара 2" },
                new Product { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Товар 3", Cost = 150.00m, Description = "Описание товара 3" },
                new Product { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Товар 4", Cost = 300.99m, Description = "Описание товара 4" },
                new Product { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Товар 5", Cost = 75.25m, Description = "Описание товара 5" },
                new Product { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Товар 6", Cost = 120.00m, Description = "Описание товара 6" },
                new Product { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Товар 7", Cost = 90.45m, Description = "Описание товара 7" },
                new Product { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Товар 8", Cost = 500.00m, Description = "Описание товара 8" },
                new Product { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Товар 9", Cost = 85.30m, Description = "Описание товара 9" },
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Товар 10", Cost = 250.60m, Description = "Описание товара 10" }
            };
            modelBuilder.Entity<Product>().HasData(basicProducts);
        }
    }
}
