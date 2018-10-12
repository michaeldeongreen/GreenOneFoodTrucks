using GreenOneFoodTrucks.Services.Interfaces;
using System;
using System.Collections.Generic;
using GreenOneFoodTrucks.Common.Interfaces;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Common;
using System.Linq;

namespace GreenOneFoodTrucks.Services
{
    public class WithinQueryBuilder : IQueryBuilder
    {
        private readonly IAppSettingsManager _appSettingsManager;
        private readonly QueryType _queryType;
        private IEnumerable<FieldFilter> _fieldFilters;
        private const string LatitudeFieldName = "latitude";
        private const string LongitudeFieldName = "longitude";

        public WithinQueryBuilder(IAppSettingsManager appSettingsManager)
        {
            _appSettingsManager = appSettingsManager;
            _queryType = QueryType.Within;
        }

        public string Build(IEnumerable<FieldFilter> fieldFilters)
        {
            const string location = "location";

            if (!IsValid(fieldFilters))
                throw new ArgumentException("One or more field filter parameters is invalid");

            _fieldFilters = fieldFilters;

            FieldFilter latitude = _fieldFilters.Where(n => string.Equals(n.Name, LatitudeFieldName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            FieldFilter longitude = _fieldFilters.Where(n => string.Equals(n.Name, LongitudeFieldName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

            string query = $"within_circle({location}, {latitude.Value}, {longitude.Value}, {_appSettingsManager.AppSettings.Value.RadiusOfCentralCoordinateInMeters})";

            return query;
        }

        public bool IsQueryType(QueryType queryType)
        {
            return _queryType == queryType;
        }

        public bool IsValid(IEnumerable<FieldFilter> fieldFilters)
        {
            if (fieldFilters == null || fieldFilters.Count() != 2 ||
                fieldFilters.Where(n => string.Equals(n.Name, LatitudeFieldName, StringComparison.OrdinalIgnoreCase)).Count() == 0 ||
                fieldFilters.Where(n => string.Equals(n.Name, LongitudeFieldName, StringComparison.OrdinalIgnoreCase)).Count() == 0 ||
                fieldFilters.Where(n => String.IsNullOrEmpty(n.Value)).Count() > 0
                )
                return false;
            else
                return true;
        }
    }
}
