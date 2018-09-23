using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.DTO;

namespace MakingAnOrder.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(OrderFilterDTO orderFilter);
        int MakeOrder(IEnumerable<MakeOrderProductDTO> products);
    }
}
