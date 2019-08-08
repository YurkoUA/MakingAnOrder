using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Repositories;
using MakingAnOrder.Infrastructure.Services;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Business.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<IEnumerable<ProductVM>> GetProductsAsync()
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var products = await repo.GetAllProductsAsync();
                return mapper.ConvertCollectionTo<ProductVM>(products);
            }
        }

        public async Task<ProductVM> GetProductAsync(int id)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var product = await repo.GetProductAsync(id);
                return mapper.ConvertTo<ProductVM>(product);
            }
        }

        public async Task<int> CreateProductAsync(ProductVM product)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var productEM = mapper.ConvertTo<Product>(product);
                return await repo.CreateProductAsync(productEM);
            }
        }

        public async Task EditProductAsync(ProductVM product)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                await repo.EditProductAsync(mapper.ConvertTo<Product>(product));
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            {
                await repo.DeleteProductAsync(id);
            }
        }
    }
}
