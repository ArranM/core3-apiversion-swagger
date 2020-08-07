using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace APISwaggerTest.V1.Controllers
{
    /// <summary>
    /// Represents a RESTful weather service.
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets weather.
        /// </summary>
        /// <param name="id">The requested weather identifier.</param>
        /// <returns>The requested weather forecast.</returns>
        /// <response code="200">The weather was successfully retrieved.</response>
        /// <response code="404">The waather does not exist.</response>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(result);
        }
    }
}
