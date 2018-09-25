using System.Collections.Generic;
using System.Data;
using System.Linq;
using MakingAnOrder.Infrastructure.DTO;

namespace MakingAnOrder.Infrastructure.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable AsDataTableParam(this IEnumerable<MakeOrderProductDTO> products)
        {
            var table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Discount");
            table.Columns.Add("Quantity");

            if (products?.Any() == true)
            {
                foreach (var item in products)
                {
                    table.Rows.Add(item.Id, item.Discount, item.Quantity);
                }
            }

            return table;
        }
    }
}
