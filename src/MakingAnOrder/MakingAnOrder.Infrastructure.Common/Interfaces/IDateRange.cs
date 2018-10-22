using System;

namespace MakingAnOrder.Infrastructure.Common.Interfaces
{
    public interface IDateRange
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
