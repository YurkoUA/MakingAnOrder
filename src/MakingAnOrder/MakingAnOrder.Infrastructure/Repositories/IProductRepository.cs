using System.Collections.Generic;
using MakingAnOrder.Data.Entity;

namespace MakingAnOrder.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);

        int CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);
    }
}
