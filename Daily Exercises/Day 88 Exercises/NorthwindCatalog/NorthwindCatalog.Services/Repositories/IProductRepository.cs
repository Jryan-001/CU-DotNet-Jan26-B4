using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.Dtos;

namespace NorthwindCatalog.Services.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}
