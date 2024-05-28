using Microsoft.EntityFrameworkCore;
using MultiLayer.Core.Models;
using MultiLayer.Core.Repositories;

namespace MultiLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await Context.Categories
                .Include(x => x.Products)
                .Where(x => x.Id == categoryId)
                .SingleOrDefaultAsync();
        }
    }
}
