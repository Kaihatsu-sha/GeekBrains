using ASP.One.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.One.Controllers
{
    [Route("apiv2/wf")]
    [ApiController]
    public class MyWeatherForecast : ControllerBase
    {
        ILogger<MyWeatherForecast> _logger;
        IMock _weatherForecastMock;

        public MyWeatherForecast(ILogger<MyWeatherForecast> logger, IMock mock)
        {
            _logger = logger;
            _weatherForecastMock = mock;
        }

        [HttpPost("show")]
        public IActionResult ReturnData()
        {
            string hourS = HttpContext.Request.Query["hourStart"].ToString();
            Int32.TryParse(hourS, out int hourStart);
            string hourE = HttpContext.Request.Query["hourEnd"].ToString();
            Int32.TryParse(hourE, out int hourEnd);

            if (hourStart == 0 || hourEnd == 0)
            {
                return base.Ok(_weatherForecastMock.Get());
            }

            List<SimpleWeatherForecast> iEnumerable = _weatherForecastMock.Get().ToList();
            List<SimpleWeatherForecast> show = new List<SimpleWeatherForecast>();

            foreach (SimpleWeatherForecast forecast in iEnumerable)
            {
                if (forecast.Time.Hour >= hourStart && forecast.Time.Hour <= hourEnd)
                {
                    show.Add(forecast);
                }
            }
            return Ok(show);
        }

        [HttpPost("del")]
        public IActionResult DeletedData()
        {
            string hourS = HttpContext.Request.Query["hourStart"].ToString();
            Int32.TryParse(hourS, out int hourStart);
            string hourE = HttpContext.Request.Query["hourEnd"].ToString();
            Int32.TryParse(hourE, out int hourEnd);

            if (hourStart == 0 || hourEnd == 0)
            {
                return base.Ok(_weatherForecastMock.Get());
            }

            List<SimpleWeatherForecast> iEnumerable = _weatherForecastMock.Get().ToList();
            List<SimpleWeatherForecast> delete = new List<SimpleWeatherForecast>();

            foreach (SimpleWeatherForecast forecast in iEnumerable)
            {
                if (forecast.Time.Hour >= hourStart && forecast.Time.Hour <= hourEnd)
                {
                    delete.Add(forecast);
                }
            }

            foreach (SimpleWeatherForecast forecast in delete)
            {
                iEnumerable.Remove(forecast);
            }

            _weatherForecastMock.Set(iEnumerable);
            return Ok(iEnumerable);
        }

        [HttpPost("edit")]
        public IActionResult Edit()
        {
            string hourS = HttpContext.Request.Query["hour"].ToString();
            Int32.TryParse(hourS, out int hour);
            string temperatureS = HttpContext.Request.Query["temperature"].ToString();
            Int32.TryParse(temperatureS, out int temperature);

            List<SimpleWeatherForecast> iEnumerable = _weatherForecastMock.Get().ToList();

            foreach (SimpleWeatherForecast forecast in iEnumerable)
            {
                if (forecast.Time.Hour == hour)
                {
                    forecast.TemperatureC = temperature;
                    forecast.Summary = "Edited";
                    return Ok("Отредактирован");
                }
            }

            return Ok("Не найдено");
        }

        [HttpPost("add")]
        public IActionResult Add()
        {
            string hourS = HttpContext.Request.Query["hour"].ToString();
            Int32.TryParse(hourS, out int hour);
            string temperatureS = HttpContext.Request.Query["temperature"].ToString();
            Int32.TryParse(hourS, out int temperature);

            List<SimpleWeatherForecast> iEnumerable = _weatherForecastMock.Get().ToList();
            SimpleWeatherForecast newItem = new SimpleWeatherForecast()
            {
                Time = new TimeOnly(hour, 0),
                Summary = "Add item",
                Date = DateTime.Now,
                TemperatureC = temperature
            };
            iEnumerable.Add(newItem);
            _weatherForecastMock.Set(iEnumerable);

            return Ok("Добавлен объект");
        }
    }
}
