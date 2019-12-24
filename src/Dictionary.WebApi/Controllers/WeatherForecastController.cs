using System;
using System.Collections.Generic;
using System.Linq;
using Dictionary.Services;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dictionary.WebApi.Controllers
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
        private readonly IWordService _wordService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
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

        [HttpGet("list")]
        public List<WordListServiceModel> List(int l)
        {
            return _wordService.List(l);
        }

        [HttpPost("create")]
        public void Create(string name)
        {
            _wordService.Create(new WordCreateServiceModel { Name = name });
        }
    }
}
