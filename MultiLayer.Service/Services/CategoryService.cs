using AutoMapper;
using MultiLayer.Core.DTOs;
using MultiLayer.Core.Models;
using MultiLayer.Core.Repositories;
using MultiLayer.Core.Services;
using MultiLayer.Core.UnitOfWorks;

namespace MultiLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            IGenericRepository<Category> repository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
