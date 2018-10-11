using Lamar;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenOneFoodTrucks.Services
{
    public class ServicesRegistry : ServiceRegistry
    {
        public ServicesRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
