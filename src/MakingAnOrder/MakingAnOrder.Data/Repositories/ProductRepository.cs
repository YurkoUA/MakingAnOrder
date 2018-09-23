using System.Collections.Generic;
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

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll<Product>();
        }

        public Product GetProduct(int id)
        {
            return Get<Product>(id);
        }

        public int CreateProduct(Product product)
        {
            return Insert(product);
        }

        public void EditProduct(Product product)
        {
            Update(product);
        }

        public void DeleteProduct(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);

            ExecuteSP("USPProductDelete", param);
        }
    }
}
