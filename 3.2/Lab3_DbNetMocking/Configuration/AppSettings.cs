using NetDbMockApp.Interfaces;
using System.Configuration;

namespace NetDbMockApp.Configuration
{
    internal class AppSettings : IAppSettings
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}