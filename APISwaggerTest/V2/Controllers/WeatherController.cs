using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APISwaggerTest.V2.Controllers
{
    /// <summary>
    /// Represents a RESTful weather service.
    /// </summary>
    [ApiController]
    [ApiVersion("2")]
    [ApiVersion("1", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherController : ControllerBase
    {
        private ILogger<WeatherController> _logger;

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
        /// <response code="404">The weather does not exist.</response>
        [HttpGet("{id:int}"), MapToApiVersion("2")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var result = "no weather today";

            return Ok(result);
        }
    }
}
