using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableResponseVM<TData> where TData : class
    {
        [JsonProperty("data")]
        public IEnumerable<TData> Data { get; set; } = new List<TData>();

        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
    }
}
