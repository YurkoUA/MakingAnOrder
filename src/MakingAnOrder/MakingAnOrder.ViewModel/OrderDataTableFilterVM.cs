using System;
using MakingAnOrder.ViewModel.DataTable;

namespace MakingAnOrder.ViewModel
{
    public class OrderDataTableFilterVM : DataTableRequestVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
