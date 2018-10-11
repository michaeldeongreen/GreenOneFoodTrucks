using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GreenOneFoodTrucks.Services.Interfaces;

namespace GreenOneFoodTrucks.Web.Api.Controllers
{
    public class FoodTruckController : Controller
    {
        private readonly IHttpService _httpService;
        public FoodTruckController(IHttpService httpService)
        {
            _httpService = httpService;
        }
        [HttpGet]
        [Route("api/foodtruck/latitude/{latitude}/longitude/{longitude}")]
        public IEnumerable<string> Get(double latitude, double longitude)
        {
            _httpService.GetFoodTrucks("https://data.sfgov.org");
            return new string[] { "value1", "value2" };
        }
    }
}