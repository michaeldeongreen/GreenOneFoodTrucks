using GreenOneFoodTrucks.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace GreenOneFoodTrucks.Common
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IOptions<AppSettings> _appSettings;
        public IOptions<AppSettings> AppSettings => _appSettings;
        public AppSettingsManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
    }
}
