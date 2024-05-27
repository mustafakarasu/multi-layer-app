using MultiLayer.Core.Models;

namespace MultiLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProducts();
    }
}
