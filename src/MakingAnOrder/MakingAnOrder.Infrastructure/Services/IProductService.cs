using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Services
{
    public interface IProductService : IDisposable
    {
        Task<IEnumerable<ProductVM>> GetProductsAsync();
        Task<ProductVM> GetProductAsync(int id);

        Task<int> CreateProductAsync(ProductVM product);
        Task EditProductAsync(ProductVM product);
        Task DeleteProductAsync(int id);
    }
}
