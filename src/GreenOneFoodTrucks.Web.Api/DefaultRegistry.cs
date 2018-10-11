using Lamar;

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
        }
    }
}
