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

            var list = document.QuerySelectorAll("div[span]")//.Where(item => item.ClassName != null && item.ClassName == "value")

                .Select(item => item.TextContent).ToArray();
            /*document.QuerySelectorAll("meta[content='IE=edge']")
                .Select(el => el.GetAttribute(@"title")).ToArray();*/
            /*document.QuerySelectorAll("span") meta http-equiv="X-UA-Compatible" content="IE=edge"
               .Where(item => item.ClassName != null && item.ClassName.Contains("temp__value"))
               .Select(item => item.TextContent).ToArray();*/

            foreach (var el in list)
            {
                Weather weather = new Weather();
                weather.Temperature = el;
                weathers.Add(weather);
            }

            return weathers;
        }
    }
}
