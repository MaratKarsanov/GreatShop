using GreatShop.Application.DTOs;

namespace GreatShop.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDto?> TryGetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<ProductDto?> UpdateAsync(Guid id, UpdateProductDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<IReadOnlyList<ProductDto>> GetAllAsync();
    }
}
