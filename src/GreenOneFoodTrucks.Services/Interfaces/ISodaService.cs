using GreenOneFoodTrucks.Domain;
using System.Collections.Generic;

namespace GreenOneFoodTrucks.Services.Interfaces
{
    public interface ISodaService
    {
        IEnumerable<FoodTruck> GetFoodTrucks(Coordinate coordinate);
    }
}
