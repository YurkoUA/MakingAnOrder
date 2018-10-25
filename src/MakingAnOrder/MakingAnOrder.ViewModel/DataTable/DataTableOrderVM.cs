using MakingAnOrder.Infrastructure.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableOrderVM
    {
        public int Column { get; set; }
        public OrderDirection Dir { get; set; }
    }
}
