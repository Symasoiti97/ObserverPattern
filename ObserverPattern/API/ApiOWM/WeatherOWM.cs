using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ObserverPattern.API.ApiOWM
{
    class WeatherOWM : IApiXml<Weather>, IApiJson<Weather>
    {
        #region[GetJson]
        public Weather GetJson(JObject json)
        {
            JObject weatherArray = (JObject)json["main"];
            return new Weather
            {
                Temperature = (string)weatherArray["temp"].ToString(),
                Humidity = (string)weatherArray["humidity"].ToString(),
                Pressure = (string)weatherArray["pressure"].ToString()
            };
        }
        #endregion

        #region[GetXml]
        public Weather GetXml(XDocument xDocument)
        {
            var weather = xDocument.Element("current");

            return new Weather
            {
                Temperature = (string)weather.Element("temperature").Attribute("value").Value.ToString(),
                Humidity = (string)weather.Element("humidity").Attribute("value").Value.ToString(),
                Pressure = (string)weather.Element("pressure").Attribute("value").Value.ToString()
            };
        }
        #endregion
    }
}
