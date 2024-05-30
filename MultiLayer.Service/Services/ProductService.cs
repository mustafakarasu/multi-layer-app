using AutoMapper;
using MultiLayer.Core.DTOs;
using MultiLayer.Core.Models;
using MultiLayer.Core.Repositories;
using MultiLayer.Core.Services;
using MultiLayer.Core.UnitOfWorks;

namespace MultiLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IGenericRepository<Product> repository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
