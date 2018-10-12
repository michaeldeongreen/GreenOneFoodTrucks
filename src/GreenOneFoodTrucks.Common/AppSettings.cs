using System;

namespace GreenOneFoodTrucks.Common
{
    public class AppSettings
    {
        public string AppToken { get; set; }
        public int SoqlQueryLimit { get; set; }
        public int RadiusOfCentralCoordinateInMeters { get; set; }
        public string ResourceId { get; set; }
        public string SanFranciscoFoodTruckApiUrl { get; set; }
    }
}
