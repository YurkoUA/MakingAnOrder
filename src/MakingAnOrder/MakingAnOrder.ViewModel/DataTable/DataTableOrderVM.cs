using Newtonsoft.Json;
using MakingAnOrder.Infrastructure.Common.Enums;

namespace MakingAnOrder.ViewModel.DataTable
{
    public class DataTableOrderVM
    {
        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("dir")]
        public OrderDirection Dir { get; set; }
    }
}
