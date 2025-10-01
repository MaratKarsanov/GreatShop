using GreatShop.Application.DTOs;
using GreatShop.Application.Interfaces.Repositories;
using GreatShop.Domain.Entities;
using GreatShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GreatShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product, CancellationToken ct = default)
        {
            await _dbContext.Products.AddAsync(product, ct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> RemoveAsync(Guid id, CancellationToken ct = default)
        {
            var product = await TryGetByIdAsync(id);
            if (product is null)
            {
                return false;
            }
            var isRemoved = _dbContext
                .Products
                .Remove(product).State == EntityState.Deleted;
            await _dbContext.SaveChangesAsync(ct);
            return isRemoved;
        }

        public async Task<IReadOnlyList<Product>> TryGetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Products.ToListAsync(ct);
        }

        public async Task<Product?> TryGetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task<Product> UpdateAsync(Guid id, UpdateProductDto dto, CancellationToken ct = default)
        {
            var product = await TryGetByIdAsync(id);
            if (product is null)
            {
                return null;
            }

            product.Name = dto.Name;
            product.Cost = dto.Cost;
            product.Description = dto.Description;
            await _dbContext.SaveChangesAsync(ct);

            return product;
        }
    }
}
