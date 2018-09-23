using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;

namespace MakingAnOrder.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);

        int CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);
    }
}
