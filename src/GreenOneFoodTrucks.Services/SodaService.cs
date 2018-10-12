using GreenOneFoodTrucks.Services.Interfaces;
using System;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Common.Interfaces;
using SODA;
using System.Collections.Generic;

namespace GreenOneFoodTrucks.Services
{
    public class SodaService : ISodaService
    {
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        public SodaService(IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _configurationManagerWrapper = configurationManagerWrapper;
        }
        public int GetFoodTrucks(string url)
        {
            var client = new SodaClient(url, _configurationManagerWrapper.AppSettings.Value.AppToken);
            var resource = client.GetResource<Dictionary<string, object>>(_configurationManagerWrapper.AppSettings.Value.ResourceId);
            var soql = new SoqlQuery().Where("within_circle(location, 37.7678524427181, -122.416104892532, 500)");
            var results = resource.Query<FoodTruck>(soql);
            return -1;
        }
    }
}
