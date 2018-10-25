using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableRequestVM
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTableSearchVM Search { get; set; }
        public IEnumerable<DataTableOrderVM> Order { get; set; }
        public IEnumerable<DataTableColumnVM> Column { get; set; }
    }
}
