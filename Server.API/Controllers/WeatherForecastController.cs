using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Server.API.Controllers;

public class PostRequestDto
{
    [DefaultValue(10)]
    [SwaggerParameter(Description = "Minimum temperature", Required = true)]
    public int minTemperature { get; set; }

    [DefaultValue(20)]
    [SwaggerParameter(Description = "Maximum temperature", Required = true)]
    public int maxTemperature { get; set; }
}

public class GetRequestDto
{
    [FromQuery]
    [DefaultValue(5)]
    [SwaggerParameter(Description = "Length of the return value", Required = true)]
    public int count { get; set; }

    [FromQuery]
    [DefaultValue(10)]
    [SwaggerParameter(Description = "Minimum temperature", Required = true)]
    public int minTemperature { get; set; }

    [FromQuery]
    [DefaultValue(20)]
    [SwaggerParameter(Description = "Maximum temperature", Required = true)]
    public int maxTemperature { get; set; }
}

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

    [HttpPost("generate")]
    [SwaggerOperation(Summary = "Generate weather data", Description = "Generate a list of weather forecasts based on input parameters.")]
    public IActionResult PostGenerate([FromBody] PostRequestDto request, [FromQuery, SwaggerParameter(Description = "Length of the return value", Required = true), DefaultValue(5)] int count)
    {
        if (count < 0 || request.minTemperature > request.maxTemperature)
        {
            return BadRequest("Count have to be a positive integer or max temperature have to be greater than min temperature");
        }

        return Ok(_weatherForecastService.Generate(request.minTemperature, request.maxTemperature, count));
    }

    [HttpGet("generate")]
    [SwaggerOperation(Summary = "Generate weather data", Description = "Generate a list of weather forecasts based on input parameters.")]
    public IActionResult GetGenerate([FromQuery] GetRequestDto requestDto)
    {
        if (requestDto.count < 0 || requestDto.minTemperature > requestDto.maxTemperature)
        {
            return BadRequest("Count have to be a positive integer or max temperature have to be greater than min temperature");
        }

        return Ok(_weatherForecastService.Generate(requestDto.minTemperature, requestDto.maxTemperature, requestDto.count));
    }
}
