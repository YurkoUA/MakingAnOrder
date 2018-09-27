using System.Configuration;

namespace MakingAnOrder.Bootstrap
{
    public static class AppConfigurationHelper
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
