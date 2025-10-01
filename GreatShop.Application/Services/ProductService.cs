using AutoMapper;
using GreatShop.Application.DTOs;
using GreatShop.Application.Interfaces.Repositories;
using GreatShop.Application.Interfaces.Services;
using GreatShop.Domain.Entities;

namespace GreatShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product()
            {
                Name = dto.Name,
                Cost = dto.Cost,
                Description = dto.Description
            };
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var isDeleted = await _productRepository.RemoveAsync(id);
            
            return isDeleted;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.TryGetAllAsync();
            return _mapper.Map<IReadOnlyList<ProductDto>>(products);
        }

        public async Task<ProductDto?> TryGetByIdAsync(Guid id)
        {
            var product = await _productRepository.TryGetByIdAsync(id);
            return product is null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto?> UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _productRepository.UpdateAsync(id, dto);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
