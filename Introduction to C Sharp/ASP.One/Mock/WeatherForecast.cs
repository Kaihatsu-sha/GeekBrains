using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.One.Mock
{
    public class SimpleWeatherForecast
    {
        public DateTime Date { get; set; }

        public TimeOnly Time { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public interface IMock
    {
        public IEnumerable<SimpleWeatherForecast> Get();
        public void Set(IEnumerable<SimpleWeatherForecast> value);
    }

    public class WeatherForecastMock : IMock
    {
        IEnumerable<SimpleWeatherForecast> _weatherForecasts;

        public WeatherForecastMock()
        {
            Random rng = new Random();

            _weatherForecasts = Enumerable.Range(1, 5).Select(index => new SimpleWeatherForecast
            {
                Date = DateTime.Now,
                Time = new TimeOnly(10 + index, 00),
                TemperatureC = rng.Next(-20, 55),
                Summary = "Test value"
            })
            .ToArray();
        }

        public IEnumerable<SimpleWeatherForecast> Get()
        {
            return _weatherForecasts;
        }

        public void Set(IEnumerable<SimpleWeatherForecast> weatherForecasts)
        {
            _weatherForecasts = weatherForecasts;
        }
    }
}
