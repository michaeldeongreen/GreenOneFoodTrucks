using FluentAssertions;
using GreenOneFoodTrucks.Common;
using GreenOneFoodTrucks.Common.Interfaces;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Services;
using GreenOneFoodTrucks.Services.Interfaces;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenOneFoodTrucks.Unit.Tests.Services
{
    [TestFixture]
    public class WithinQueryBuilderTests
    {
        [Test]
        public void IsValid_given_only_latitude_when_isvalid_then_returnfalse()
        {
            //given
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            IAppSettingsManager appSettingsManager = new AppSettingsManager(appSettings);
            var fieldFilters = new List<FieldFilter>() { new FieldFilter("Latitude", "99.452") };
            //when
            IQueryBuilder queryBuilder = new WithinQueryBuilder(appSettingsManager);
            bool result = queryBuilder.IsValid(fieldFilters);
            //then
            result.Should().BeFalse();
        }

        [Test]
        public void IsValid_given_only_longitude_when_isvalid_then_returnfalse()
        {
            //given
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            IAppSettingsManager appSettingsManager = new AppSettingsManager(appSettings);
            var fieldFilters = new List<FieldFilter>() { new FieldFilter("Longitude", "99.452") };
            //when
            IQueryBuilder queryBuilder = new WithinQueryBuilder(appSettingsManager);
            bool result = queryBuilder.IsValid(fieldFilters);
            //then
            result.Should().BeFalse();
        }

        [Test]
        public void IsValid_given_correct_parameters_when_isvalid_then_returntrue()
        {
            //given
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            IAppSettingsManager appSettingsManager = new AppSettingsManager(appSettings);
            var fieldFilters = new List<FieldFilter>() { new FieldFilter("Latitude", "99.452"), new FieldFilter("Longitude", "35.3333")};
            //when
            IQueryBuilder queryBuilder = new WithinQueryBuilder(appSettingsManager);
            bool result = queryBuilder.IsValid(fieldFilters);
            //then
            result.Should().BeTrue();
        }
    }
}
