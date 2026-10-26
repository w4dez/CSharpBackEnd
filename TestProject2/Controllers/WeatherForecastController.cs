using Microsoft.AspNetCore.Mvc;

namespace TestProject2.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

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


    [HttpGet("Rotkreutz")]
    public ActionResult<string> WeatherRotkreutz()
    {
        string[] list = ["sunny", "cloudy", "rainy", "foggy"];
        List<string> weatherList = new List<string>(list);
        string[] arr = weatherList.ToArray();

        string element = arr.First();

        return Ok("Foggy");
    }
}
