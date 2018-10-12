using GreenOneFoodTrucks.Common.Interfaces;
using GreenOneFoodTrucks.Domain;
using System.Collections.Generic;

namespace GreenOneFoodTrucks.Services.Interfaces
{
    public interface IBuildQuery
    {
        string Build(IAppSettingsManager appSettingsManager, IList<FieldFilter> fieldFilters);
    }
}
