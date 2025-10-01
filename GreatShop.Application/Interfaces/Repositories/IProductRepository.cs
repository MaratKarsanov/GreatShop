using GreatShop.Application.DTOs;
using GreatShop.Domain.Entities;

namespace GreatShop.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> TryGetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> TryGetAllAsync(CancellationToken ct = default);
        Task AddAsync(Product product, CancellationToken ct = default);
        Task<Product> UpdateAsync(Guid id, UpdateProductDto dto, CancellationToken ct = default);
        Task<bool> RemoveAsync(Guid id, CancellationToken ct = default);
    }
}
