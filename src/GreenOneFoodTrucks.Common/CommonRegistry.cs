using Lamar;

namespace GreenOneFoodTrucks.Common
{
    public class CommonRegistry : ServiceRegistry
    {
        public CommonRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
