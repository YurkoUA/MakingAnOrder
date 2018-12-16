using System.Linq;
using AutoMapper;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.ViewModel;
using MakingAnOrder.ViewModel.DataTable;

namespace MakingAnOrder.Infrastructure.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<ProductOrder, ProductOrderVM>();

            CreateMap<MakeOrderVM, MakeOrderProductDTO>();

            CreateMap<DataTableRequestVM, OrderFilterVM>()
                .ForMember(dest => dest.Offset, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.Take, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Column, opt => opt.Condition(src => src.Columns?.Any() == true))
                .ForMember(dest => dest.Direction, opt => opt.Condition(src => src.Order?.Any() == true))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.Columns.ToList()[src.Order.First().Column].Name))
                .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.Order.First().Dir));

            CreateMap<OrderDataTableFilterVM, OrderFilterVM>()
                .ForMember(dest => dest.Offset, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.Take, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Column, opt => opt.Condition(src => src.Columns?.Any() == true))
                .ForMember(dest => dest.Direction, opt => opt.Condition(src => src.Order?.Any() == true))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.Columns.ToList()[src.Order.First().Column].Name))
                .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.Order.First().Dir));
        }
    }
}
