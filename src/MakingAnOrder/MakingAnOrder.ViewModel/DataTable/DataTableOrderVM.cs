using MakingAnOrder.Infrastructure.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableOrderVM
    {
        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("dir")]
        public OrderDirection Direction { get; set; }
    }
}
