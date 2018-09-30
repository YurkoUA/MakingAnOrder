using System;
using System.Collections.Generic;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Services
{
    public interface IOrderService : IDisposable
    {
        IEnumerable<OrderVM> GetOrders(OrderFilterDTO orderFilter, out int totalCount);
        int MakeOrder(IEnumerable<MakeOrderProductDTO> products);
    }
}
