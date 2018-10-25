using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableRequestVM
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("search")]
        public DataTableSearchVM Search { get; set; }

        [JsonProperty("order")]
        public IEnumerable<DataTableOrderVM> Order { get; set; }

        [JsonProperty("column")]
        public IEnumerable<DataTableColumnVM> Columns { get; set; }
    }
}
