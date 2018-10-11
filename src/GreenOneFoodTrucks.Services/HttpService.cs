using GreenOneFoodTrucks.Services.Interfaces;
using System;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Common.Interfaces;
using SODA;
using System.Collections.Generic;

namespace GreenOneFoodTrucks.Services
{
    public class HttpService : IHttpService
    {
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        public HttpService(IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _configurationManagerWrapper = configurationManagerWrapper;
        }
        public int GetFoodTrucks(string url)

        {
            var client = new SodaClient(url, _configurationManagerWrapper.AppSettings.Value.AppToken);
            var resource = client.GetResource<Dictionary<string, object>>(_configurationManagerWrapper.AppSettings.Value.ResourceId);
            var soql = new SoqlQuery().Where("latitude=37.7678524427181 and longitude = -122.416104892532");
            var results = resource.Query<FoodTruck>(soql);
            return -1;
        }
    }
}
