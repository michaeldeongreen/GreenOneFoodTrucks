﻿using GreenOneFoodTrucks.Common;
using GreenOneFoodTrucks.Domain;
using System.Collections.Generic;

namespace GreenOneFoodTrucks.Services.Interfaces
{
    public interface IQueryBuilderService
    {
        string Build(IEnumerable<FieldFilter> fieldFilters);
        bool IsQueryType(QueryType queryType);
        bool IsValid(IEnumerable<FieldFilter> fieldFilters);
    }
}
