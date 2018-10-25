using System;
using MakingAnOrder.Infrastructure.Common.Enums;
using MakingAnOrder.Infrastructure.Common.Interfaces;

namespace MakingAnOrder.ViewModel
{
    public class OrderFilterVM : IPaging, IDateRange
    {
        public int Offset { get; set; } = 0;
        public int Take { get; set; } = 20;
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddYears(-1);
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddYears(1);

        public string Column { get; set; } = "Id";
        public OrderDirection Direction { get; set; } = OrderDirection.ASC;
    }
}
