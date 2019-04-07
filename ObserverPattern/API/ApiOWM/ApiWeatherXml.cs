using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObserverPattern.API
{
    class ApiWeatherXml : IApi<Weather>
    {
        public Weather Parse(string reader)
        {
            XDocument xDocument = XDocument.Parse(reader);

            var weather = xDocument.Element("current");

            return new Weather
            {
                Temperature = (string)weather.Element("temperature").Attribute("value").Value.ToString(),
                Humidity = (string)weather.Element("humidity").Attribute("value").Value.ToString(),
                Pressure = (string)weather.Element("pressure").Attribute("value").Value.ToString()
            };
        }
    }
}
