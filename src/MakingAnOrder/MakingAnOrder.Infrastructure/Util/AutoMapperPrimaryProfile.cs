using AutoMapper;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.ViewModel;
using MakingAnOrder.ViewModel.DataTable;

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

            CreateMap<MakeOrderVM, MakeOrderProductDTO>();

            CreateMap<DataTableRequestVM, OrderFilterVM>()
                .ForMember(dest => dest.Offset, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.Take, opt => opt.MapFrom(src => src.Length));
        }
    }
}
