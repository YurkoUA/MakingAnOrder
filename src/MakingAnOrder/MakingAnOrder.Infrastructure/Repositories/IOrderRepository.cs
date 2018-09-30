using System.Collections.Generic;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.DTO;

namespace MakingAnOrder.Infrastructure.Repositories
{   
    public interface IOrderRepository : IRepository
    {
        IEnumerable<Order> GetAllOrders(OrderFilterDTO orderFilter, out int totalCount);
        int MakeOrder(IEnumerable<MakeOrderProductDTO> products);
    }
}
