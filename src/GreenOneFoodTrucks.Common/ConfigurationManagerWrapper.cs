using GreenOneFoodTrucks.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace GreenOneFoodTrucks.Common
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        private readonly IOptions<AppSettings> _appSettings;
        public IOptions<AppSettings> AppSettings => _appSettings;
        public ConfigurationManagerWrapper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
    }
}
