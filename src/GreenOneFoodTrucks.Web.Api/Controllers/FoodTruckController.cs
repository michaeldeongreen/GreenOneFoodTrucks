using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GreenOneFoodTrucks.Services.Interfaces;
using GreenOneFoodTrucks.Domain;

namespace GreenOneFoodTrucks.Web.Api.Controllers
{
    public class FoodTruckController : Controller
    {
        private readonly ISodaService _sodaService;

        public FoodTruckController(ISodaService sodaService)
        {
            _sodaService = sodaService;
        }

        [HttpGet]
        [Route("api/foodtrucks/latitude/{latitude}/longitude/{longitude}")]
        public IEnumerable<FoodTruck> Get(double latitude, double longitude)
        {
            var results = _sodaService.GetFoodTrucks(new Coordinate(latitude, longitude));
            return results;
        }
    }
}