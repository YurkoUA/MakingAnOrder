using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.Infrastructure.Repositories;

namespace MakingAnOrder.Data.Repositories
{
    public class OrderRepository : DapperRepository, IOrderRepository
    {
        public OrderRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Order> GetAllOrders(OrderFilterDTO orderFilter)
        {
            throw new NotImplementedException();
        }

        public int MakeOrder(IEnumerable<MakeOrderProductDTO> products)
        {
            throw new NotImplementedException();
        }
    }
}
