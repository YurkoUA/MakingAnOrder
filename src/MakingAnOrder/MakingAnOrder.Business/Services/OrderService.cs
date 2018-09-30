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

        public IEnumerable<OrderVM> GetOrders(OrderFilterDTO orderFilter, out int totalCount)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            using (var mapper = Factory.GetService<IMappingService>())
            {
                var orders = repo.GetAllOrders(orderFilter, out int _totalCount);
                totalCount = _totalCount;
                return mapper.ConvertCollectionTo<OrderVM>(orders);
            }
        }

        public int MakeOrder(IEnumerable<MakeOrderProductDTO> products)
        {
            using (var repo = Factory.GetService<IOrderRepository>())
            {
                return repo.MakeOrder(products);
            }
        }
    }
}
