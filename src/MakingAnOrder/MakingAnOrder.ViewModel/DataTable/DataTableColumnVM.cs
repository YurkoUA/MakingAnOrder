using Newtonsoft.Json;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableColumnVM
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("orderable")]
        public bool Orderable { get; set; }

        [JsonProperty("search")]
        public DataTableSearchVM Search { get; set; }
    }
}
