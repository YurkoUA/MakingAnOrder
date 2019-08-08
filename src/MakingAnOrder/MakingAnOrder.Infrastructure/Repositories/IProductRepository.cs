using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;

namespace MakingAnOrder.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int id);

        Task<int> CreateProductAsync(Product product);
        Task EditProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
