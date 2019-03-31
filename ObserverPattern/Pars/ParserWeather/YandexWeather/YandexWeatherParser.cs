using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using ObserverPattern.Pars.ParserWeather;

namespace ObserverPattern.Pars.ParserNewsRambler
{
    class YandexWeatherParser : IParser<List<Weather>>
    {
        public List<Weather> Parse(IHtmlDocument document)
        {
            List<Weather> weathers = new List<Weather>();

            var listTemp = document.QuerySelectorAll("span.unit.unit_temperature_c")
                               .Select(item => item.TextContent).ToArray();
            var listTimeOfDay = document.QuerySelectorAll("span.time_of_day")
                               .Select(item => item.TextContent).ToArray();

            for(int i = 0; i < listTemp.Length; i++)
            {
                Weather weather = new Weather();
                weather.Temperature = listTemp[i];
                weather.TimeOfDay = listTimeOfDay[i];
                weathers.Add(weather);
            }

            return weathers;
        }
    }
}
