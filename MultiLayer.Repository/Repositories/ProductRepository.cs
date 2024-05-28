using Microsoft.EntityFrameworkCore;
using MultiLayer.Core.Models;
using MultiLayer.Core.Repositories;

namespace MultiLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
