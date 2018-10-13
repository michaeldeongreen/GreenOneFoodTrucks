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
        private readonly SodaClient _sodaClient;
        private readonly SoqlQuery _soqlQuery;
        public SodaService(IAppSettingsManager appSettingsManager, IEnumerable<IQueryBuilder> queryBuilders, SodaClient sodaClient, SoqlQuery soqlQuery)

        {
            _appSettingsManager = appSettingsManager;
            _queryBuilders = queryBuilders;
            _sodaClient = sodaClient;
            _soqlQuery = soqlQuery;
        }

        public IEnumerable<FoodTruck> GetFoodTrucks(Coordinate coordinate)
        {
            var _sodaClient = new SodaClient(_appSettingsManager.AppSettings.Value.SanFranciscoFoodTruckApiUrl, _appSettingsManager.AppSettings.Value.AppToken);
            var resource = _sodaClient.GetResource<Dictionary<string, object>>(_appSettingsManager.AppSettings.Value.ResourceId);
            IQueryBuilder queryBuilder = _queryBuilders.Where(q => q.IsQueryType(QueryType.Within)).Single();
            string query = queryBuilder.Build(coordinate.ConvertToFieldFilters());
            var soql = _soqlQuery.Where(query).Limit(_appSettingsManager.AppSettings.Value.SoqlQueryLimit);
            var results = resource.Query<FoodTruck>(soql);
            return results;
        }
    }
}
