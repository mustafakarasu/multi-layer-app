using MultiLayer.Core.Models;

namespace MultiLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(int categoryId);
    }
}
