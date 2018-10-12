using FluentAssertions;
using GreenOneFoodTrucks.Domain;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GreenOneFoodTrucks.Unit.Tests.Domain
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void ConvertToFieldFilters_GivenCoordinate_When_Convert_ReturnFieldFilters_Test()
        {
            //given
            const int correctCount = 2;
            Coordinate coordinate = new Coordinate(33.22, -66.222);
            //when
            IEnumerable<FieldFilter> results = coordinate.ConvertToFieldFilters();
            //then
            results.Count().Should().Be(correctCount);
        }
    }
}
