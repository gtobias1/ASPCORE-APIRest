using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MinhaAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "TESTE", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public ActionResult<IEnumerable<WeatherForecast>> Get()
        public IEnumerable<WeatherForecast> Get()
        {
            //var valores = new string[] { "ashbd", "asdasdasd" };

            //if (valores.Length > 5000)
            //    return BadRequest();
            //else
            //    return Ok(valores); ou return valores; por causao do IEnumerable<WeatherForecast> dentro do ActionResult

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[0]
                //Summary = Summaries[rng.Next(Summaries.Length)]

            })
            .ToArray();
        }

        //GET WeatherForecast/numero
        //[HttpGet("obter-por-id/{id}")] ex
        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

    }
}
