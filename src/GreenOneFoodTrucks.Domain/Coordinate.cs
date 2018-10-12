using System.Collections.Generic;

namespace GreenOneFoodTrucks.Domain
{
    public class Coordinate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public IEnumerable<FieldFilter> ConvertToFieldFilters()
        {
            const string latitudeFieldName = "Latitude";
            const string longitudeFieldName = "Longitude";

            return new List<FieldFilter>() { new FieldFilter(latitudeFieldName, Latitude.ToString()),
                new FieldFilter(longitudeFieldName, Longitude.ToString()) };
        }
    }
}
