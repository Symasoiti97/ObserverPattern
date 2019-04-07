using Newtonsoft.Json.Linq;
using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern.API
{
    class ApiWeatherJson : IApi<Weather>
    {
        public Weather Parse(string reader)
        {
            JObject json = JObject.Parse(reader);

            JObject weatherArray = (JObject)json["main"];

            return new Weather
            {
                Temperature = (string)weatherArray["temp"].ToString(),
                Humidity = (string)weatherArray["humidity"].ToString(),
                Pressure = (string)weatherArray["pressure"].ToString()
            };
        }
    }
}
