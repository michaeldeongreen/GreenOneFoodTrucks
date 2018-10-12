using Microsoft.Extensions.Options;

namespace GreenOneFoodTrucks.Common.Interfaces
{
    public interface IAppSettingsManager
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
