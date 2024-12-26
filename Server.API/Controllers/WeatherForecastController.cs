using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers;

[ApiController]
[Route("/api")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    [Route("test")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherForecastService.Get();
    }
}
