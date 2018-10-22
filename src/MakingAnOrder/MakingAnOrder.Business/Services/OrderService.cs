using System.Collections.Generic;
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

        public IEnumerable<OrderVM> GetOrders(OrderFilterVM orderFilter, out int totalCount)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var dto = mapper.ConvertTo<OrderFilterDTO>(orderFilter);
                var orders = repo.GetAllOrders(dto, out int _totalCount);
                totalCount = _totalCount;
                return mapper.ConvertCollectionTo<OrderVM>(orders);
            }
        }

        public int MakeOrder(IEnumerable<MakeOrderVM> products)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var dto = mapper.ConvertCollectionTo<MakeOrderProductDTO>(products);
                return repo.MakeOrder(dto);
            }
        }
    }
}
