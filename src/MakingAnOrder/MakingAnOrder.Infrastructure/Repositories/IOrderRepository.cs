using System.Collections.Generic;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.DTO;

namespace MakingAnOrder.Infrastructure.Repositories
{   
    public interface IOrderRepository : IRepository
    {
        Task<(IEnumerable<Order> Orders, int TotalCount)> GetAllOrdersAsync(OrderFilterDTO orderFilter);
        Task<int> MakeOrderAsync(IEnumerable<MakeOrderProductDTO> products);
    }
}
