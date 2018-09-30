using System;
using System.Collections.Generic;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Services
{
    public interface IProductService : IDisposable
    {
        IEnumerable<ProductVM> GetProducts();
        ProductVM GetProduct(int id);

        int CreateProduct(ProductVM product);
        void EditProduct(ProductVM product);
        void DeleteProduct(int id);
    }
}
