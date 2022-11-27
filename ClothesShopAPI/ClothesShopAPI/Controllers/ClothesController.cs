﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ClothesShopAPI.Controllers
{
    public class ClothesController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public ClothesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}