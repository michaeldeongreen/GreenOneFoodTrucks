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
        public ActionResult Get(double latitude, double longitude)
        {
            try
            {
                var results = _sodaService.GetFoodTrucks(new Coordinate(latitude, longitude));
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                //log error
                return StatusCode(500);
            }
        }
    }
}