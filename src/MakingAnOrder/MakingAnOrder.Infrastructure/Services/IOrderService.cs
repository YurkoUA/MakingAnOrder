using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Infrastructure.Services
{
    public interface IOrderService : IDisposable
    {
        Task<(IEnumerable<OrderVM> Orders, int TotalCount)> GetOrdersAsync(OrderFilterVM orderFilter);
        Task<int> MakeOrderAsync(IEnumerable<MakeOrderVM> products);
    }
}
