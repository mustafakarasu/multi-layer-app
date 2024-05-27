using MultiLayer.Core.DTOs;
using MultiLayer.Core.Models;

namespace MultiLayer.Core.Services;

public interface ICategoryService : IService<Category>
{
    public Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdAsync(int categoryId);
}