using FirstDemoClassone;
using FirstDemoClassthree;
using FirstDemoClasstwo;
using Microsoft.AspNetCore.Mvc;
using SecondDemoClassone;
using SecondDemoClassthree;
using SecondDemoClasstwo;

namespace FirstDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
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
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet] 
        public IActionResult GetFirst()
        {
            return Ok(Class21.name);
        }
        [HttpGet]
        public IActionResult GetSecond()
        {
            return Ok(Class22.name);
        }
        [HttpGet]
        public IActionResult GetThird()
        {
            return Ok(Class23.name);
        }
    }
}
