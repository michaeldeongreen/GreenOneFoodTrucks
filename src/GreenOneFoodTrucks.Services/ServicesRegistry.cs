using GreenOneFoodTrucks.Services.Interfaces;
using Lamar;

namespace GreenOneFoodTrucks.Services
{
    public class ServicesRegistry : ServiceRegistry
    {
        public ServicesRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AddAllTypesOf<IQueryBuilder>();
            });
        }
    }
}
