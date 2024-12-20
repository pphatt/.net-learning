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

    [HttpGet("test")]
    public IEnumerable<WeatherForecast> Get([FromQuery] int min, [FromQuery] int max, [FromQuery] int take, [FromBody] string name)
    {
        return _weatherForecastService.Get();
    }

    [HttpGet("data/{Slug}")]
    public string Get([FromRoute] string Slug)
    {
        return Slug;
    }

    [HttpPost]
    public string MockPost([FromBody] string name)
    {
        return name;
    }

    [HttpGet("currentDay")]
    public WeatherForecast GetCurrentDate()
    {
        return _weatherForecastService.GetCurrentDay();
    }
}
