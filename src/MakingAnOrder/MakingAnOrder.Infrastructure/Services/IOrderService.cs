using System;
using System.Collections.Generic;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Services
{
    public interface IOrderService : IDisposable
    {
        IEnumerable<OrderVM> GetOrders(OrderFilterVM orderFilter, out int totalCount);
        int MakeOrder(IEnumerable<MakeOrderVM> products);
    }
}
