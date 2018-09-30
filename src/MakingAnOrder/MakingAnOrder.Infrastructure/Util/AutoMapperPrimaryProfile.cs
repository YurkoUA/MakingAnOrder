using AutoMapper;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Util
{
    public class AutoMapperPrimaryProfile : Profile
    {
        public AutoMapperPrimaryProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<ProductOrder, ProductOrderVM>();
        }
    }
}
