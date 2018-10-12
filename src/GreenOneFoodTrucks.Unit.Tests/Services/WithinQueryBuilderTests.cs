using FluentAssertions;
using GreenOneFoodTrucks.Common;
using GreenOneFoodTrucks.Common.Interfaces;
using GreenOneFoodTrucks.Domain;
using GreenOneFoodTrucks.Services;
using GreenOneFoodTrucks.Services.Interfaces;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Collections.Generic;


namespace GreenOneFoodTrucks.Unit.Tests.Services
{
    [TestFixture]
    public class WithinQueryBuilderTests
    {
        [Test]
        public void IsValid_Given_Only_Latitude_When_IsValid_Then_ReturnFalse_Test()
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
        public void IsValid_Given_Only_Longitude_When_IsValid_Then_ReturnFalse()
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
        public void IsValid_Given_Correct_Parameters_When_IsValid_Then_ReturnTrue()
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

        [Test]
        public void Build_Given_Correct_Parameters_When_Build_Then_ReturnCorrectQuery()
        {
            //given
            const string query = "within_circle(location, 37.7678524427181, -122.416104892532, 500)";
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings() { RadiusOfCentralCoordinateInMeters = 500 });
            IAppSettingsManager appSettingsManager = new AppSettingsManager(appSettings);
            var fieldFilters = new List<FieldFilter>() { new FieldFilter("Latitude", "37.7678524427181"), new FieldFilter("Longitude", "-122.416104892532") };
            //when
            IQueryBuilder queryBuilder = new WithinQueryBuilder(appSettingsManager);
            string result = queryBuilder.Build(fieldFilters);
            //then
            result.Should().Be(query);
        }
    }
}
