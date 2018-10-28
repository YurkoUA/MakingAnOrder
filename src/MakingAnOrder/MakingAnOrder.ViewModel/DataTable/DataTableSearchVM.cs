using Newtonsoft.Json;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableSearchVM
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("regex")]
        public bool Regex { get; set; }
    }
}
