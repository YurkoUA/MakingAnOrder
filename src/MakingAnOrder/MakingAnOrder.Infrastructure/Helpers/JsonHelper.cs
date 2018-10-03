using Newtonsoft.Json;

namespace MakingAnOrder.Infrastructure.Helpers
{
    public static class JsonHelper
    {
        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TObject DeserializeObject<TObject>(string json)
        {
            return JsonConvert.DeserializeObject<TObject>(json);
        }
    }
}
