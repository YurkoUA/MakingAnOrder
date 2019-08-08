using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Repositories;
using MakingAnOrder.Infrastructure.Services;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Business.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(IRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<(IEnumerable<OrderVM> Orders, int TotalCount)> GetOrdersAsync(OrderFilterVM orderFilter)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var dto = mapper.ConvertTo<OrderFilterDTO>(orderFilter);
                var orders = await repo.GetAllOrdersAsync(dto);

                return (mapper.ConvertCollectionTo<OrderVM>(orders.Orders), orders.TotalCount);
            }
        }

        public async Task<int> MakeOrderAsync(IEnumerable<MakeOrderVM> products)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var dto = mapper.ConvertCollectionTo<MakeOrderProductDTO>(products);
                return await repo.MakeOrderAsync(dto);
            }
        }
    }
}
