using Microsoft.AspNetCore.Mvc;

namespace HelloWebapi.Controllers;

//[ApiController] Attribute: Controller eylemlerinin bir Http response döneceğini taahhüt eden attribute dur.
// Controller'lar service yani iş katmanına denk gelir. WeatherForecast ile ilgili eylem bu katmanda yapılır.
[ApiController]
[Route("[controller]s")] // sonuna s koymassam ulaşmak zor olur. Routelar önemli. Web api den gelen istekleri Route niteliği ile yönlendirebiliriz.
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
}
