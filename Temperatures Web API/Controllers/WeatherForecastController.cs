using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperatures_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        double x;
        double celsius = 0;
        double fahrenheit = 0;
        double kelvin = 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int value, string from, string to)
        {
            if (to == "kelvin")
            {
                return Ok(ToK(value, from));
            }
            else if (to == "fahrenheit")
            {
                return Ok(ToF(value, from));
            }
            else if (to == "celsius")
            {
                return Ok(ToC(value, from));
            }
            else
            {
                return BadRequest("error");
            }
        }

        public double ToF(double x, string y)
        {
            if (y == ("kelvin"))
            {
                fahrenheit = (x - 273.15) * 9 / 5 + 32;
                return fahrenheit;
            }
            else if (y == "celsius")
            {
                fahrenheit = (x * 1.8) + 32;
                return fahrenheit;
            }
            else if (y == "fahrenheit")
            {
                return fahrenheit;
            }

            return 0;
        }

        public double ToC(double x, string y)
        {
            if (y == ("kelvin"))
            {
                kelvin = x - 273.15; ;
                return kelvin;
            }
            else if (y == "celsius")
            {
                celsius = x;
                return celsius;
            }
            else if (y == "fahrenheit")
            {
                celsius = (x - 32) * 5 / 9; ;
                return celsius;
            }

            return 0;

        }

        public double ToK(double x, string y)
        {
            if (y == ("kelvin"))
            {
                kelvin = x;
                return kelvin;
            }
            else if (y == "celsius")
            {
                kelvin = x + 273.15;
                return kelvin;
            }
            else if (y == "fahrenheit")
            {
                kelvin = (x - 32) * 5 / 9 + 273.15;
                return kelvin;
            }

            return 0;

        }

    }
}
