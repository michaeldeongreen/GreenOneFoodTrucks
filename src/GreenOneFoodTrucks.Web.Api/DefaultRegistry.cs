using GreenOneFoodTrucks.Common.Interfaces;
using Lamar;
using SODA;

namespace GreenOneFoodTrucks.Web.Api
{
    public class DefaultRegistry : ServiceRegistry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<SodaClient>().Use(c =>
            {
                var appSettingsManager = c.GetInstance<IAppSettingsManager>();
                return new SodaClient(appSettingsManager.AppSettings.Value.SanFranciscoFoodTruckApiUrl, appSettingsManager.AppSettings.Value.AppToken);
            });
            For<SoqlQuery>().Use<SoqlQuery>();
        }
    }
}
