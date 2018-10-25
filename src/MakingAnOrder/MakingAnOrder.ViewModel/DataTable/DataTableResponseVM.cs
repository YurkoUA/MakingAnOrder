using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableResponseVM<TData> where TData : class
    {
        public IEnumerable<TData> Data { get; set; } = new List<TData>();
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered => Data.Count();
    }
}
