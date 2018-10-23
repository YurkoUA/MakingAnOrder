using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MakingAnOrder.Data.Entity;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.Infrastructure.Extensions;
using MakingAnOrder.Infrastructure.Repositories;

namespace MakingAnOrder.Data.Repositories
{
    public class OrderRepository : DapperRepository, IOrderRepository
    {
        public OrderRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Order> GetAllOrders(OrderFilterDTO orderFilter, out int totalCount)
        {
            var param = new DynamicParameters();
            param.Add("@orderDateStart", orderFilter.StartDate);
            param.Add("@orderDateEnd", orderFilter.EndDate);
            param.Add("@offset", orderFilter.Offset);
            param.Add("@take", orderFilter.Take);
            param.Add("@orderByColumn", orderFilter.Column);
            param.Add("@orderDirection", orderFilter.Direction);
            param.Add("@totalCount", direction: ParameterDirection.Output, dbType: DbType.Int32);

            var ordersDictionary = new Dictionary<int, Order>();

            var orders = ExecuteSP<Order, ProductOrder, Order>("USPGetOrders", (order, product) =>
            {
                if (!ordersDictionary.TryGetValue(order.Id, out Order orderEntry))
                {
                    orderEntry = order;
                    orderEntry.Products = new List<ProductOrder>();
                    ordersDictionary.Add(order.Id, orderEntry);
                }

                orderEntry.Products.Add(product);
                return orderEntry;
            }, "Id", param).Distinct();

            totalCount = param.Get<int>("@totalCount");
            return orders;
        }

        public int MakeOrder(IEnumerable<MakeOrderProductDTO> products)
        {
            var param = new DynamicParameters();
            param.Add("@products", products.AsDataTableParam().AsTableValuedParameter("MakeOrderProductType"));
            param.Add("@orderId", direction: ParameterDirection.Output, dbType: DbType.Int32);

            ExecuteSP("USPMakeOrder", param);
            return param.Get<int>("@orderId");
        }
    }
}
