using Microsoft.Extensions.Options;

namespace GreenOneFoodTrucks.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
