using System.Collections.Generic;
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

        public IEnumerable<ProductVM> GetProducts()
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var products = repo.GetAllProducts();
                return mapper.ConvertCollectionTo<ProductVM>(products);
            }
        }

        public ProductVM GetProduct(int id)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var product = repo.GetProduct(id);
                return mapper.ConvertTo<ProductVM>(product);
            }
        }

        public int CreateProduct(ProductVM product)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var productEM = mapper.ConvertTo<Product>(product);
                return repo.CreateProduct(productEM);
            }
        }

        public void EditProduct(ProductVM product)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                repo.EditProduct(mapper.ConvertTo<Product>(product));
            }
        }

        public void DeleteProduct(int id)
        {
            using (var repo = Factory.GetService<IProductRepository>())
            {
                repo.DeleteProduct(id);
            }
        }
    }
}
