using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.Repositories;

namespace MakingAnOrder.Data.Repositories
{
    public class ProductRepository : DapperRepository, IProductRepository
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await GetAllAsync<Product>();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await GetAsync<Product>(id);
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            return await InsertAsync(product);
        }

        public async Task EditProductAsync(Product product)
        {
            await UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);

            await ExecuteSPAsync("USPProductDelete", param);
        }
    }
}
