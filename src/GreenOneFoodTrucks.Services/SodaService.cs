using GreenOneFoodTrucks.Services.Interfaces;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Common.Interfaces;
using SODA;
using System.Collections.Generic;
using System.Linq;
using GreenOneFoodTrucks.Common;

namespace GreenOneFoodTrucks.Services
{
    public class SodaService : ISodaService
    {
        private readonly IAppSettingsManager _appSettingsManager;
        private readonly IEnumerable<IQueryBuilder> _queryBuilders;
        public SodaService(IAppSettingsManager appSettingsManager, IEnumerable<IQueryBuilder> queryBuilders)
        {
            _appSettingsManager = appSettingsManager;
            _queryBuilders = queryBuilders;
        }

        public IEnumerable<FoodTruck> GetFoodTrucks(Coordinate coordinate)
        {
            var client = new SodaClient(_appSettingsManager.AppSettings.Value.SanFranciscoFoodTruckApiUrl, _appSettingsManager.AppSettings.Value.AppToken);
            var resource = client.GetResource<Dictionary<string, object>>(_appSettingsManager.AppSettings.Value.ResourceId);
            IQueryBuilder queryBuilder = _queryBuilders.Where(q => q.IsQueryType(QueryType.Within)).Single();
            string query = queryBuilder.Build(coordinate.ConvertToFieldFilters());
            var soql = new SoqlQuery().Where(query).Limit(_appSettingsManager.AppSettings.Value.SoqlQueryLimit);
            var results = resource.Query<FoodTruck>(soql);
            return results;
        }
    }
}
