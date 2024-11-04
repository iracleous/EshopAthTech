using EshopAthTech.Dros;
using EshopAthTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EshopAthTech.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("hello")]
        public string PrintHello()
        {
            return "hello";
        }

        [HttpGet("product")]
        public Product GetProduct()
        {
            return new Product()
            {
                 Id = 20,
                  Name ="chips",
                  Description = "Tasty",
                  Price = 1.30m
            };
        }

        [HttpPost("product")]
        public Product CreateProduct(ProductDate data)
        {
            return new Product()
            {
                Id = 20,
                Name = data.Name ?? string.Empty,
                Description = data.Description,
                Price = 1.30m
            };
        }
    }
}
