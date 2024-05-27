using MultiLayer.Core.DTOs;
using MultiLayer.Core.Models;

namespace MultiLayer.Core.Services;

public interface IProductService : IService<Product>
{
    Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetAllProducts();
}