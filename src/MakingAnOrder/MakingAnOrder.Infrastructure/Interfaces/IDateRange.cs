using System;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IDateRange
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
