using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aop.IService;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMyService myService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyService myService)
        {
            _logger = logger;
            this.myService = myService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            myService.ShowCode();
            return Ok();
        }
    }
}
