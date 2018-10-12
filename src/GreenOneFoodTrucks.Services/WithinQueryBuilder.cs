using GreenOneFoodTrucks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public WithinQueryBuilder(IAppSettingsManager appSettingsManager)
        {
            _appSettingsManager = appSettingsManager;
            _queryType = QueryType.Within;
        }

        public string Build(IEnumerable<FieldFilter> fieldFilters)
        {
            if (!IsValid(fieldFilters))
                throw new ArgumentException("One or more field filter parameters is invalid");


            _fieldFilters = fieldFilters;
            return string.Empty;
        }

        public bool IsQueryType(QueryType queryType)
        {
            return _queryType == queryType;
        }

        public bool IsValid(IEnumerable<FieldFilter> fieldFilters)
        {
            const string latitudeField = "latitude";
            const string longitudeField = "longitude";

            if (fieldFilters == null || fieldFilters.Count() != 2 ||
                fieldFilters.Where(n => string.Equals(n.Name, latitudeField, StringComparison.OrdinalIgnoreCase)).Count() == 0 ||
                fieldFilters.Where(n => string.Equals(n.Name, longitudeField, StringComparison.OrdinalIgnoreCase)).Count() == 0 ||
                fieldFilters.Where(n => String.IsNullOrEmpty(n.Value)).Count() > 0
                )
                return false;
            else
                return true;
        }
    }
}
