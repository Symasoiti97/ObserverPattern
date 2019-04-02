using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.API.ApiOWM
{
    class WeatherOWMSetting : IApiSetting
    {
        public string Url { get; set; } = "http://api.openweathermap.org/data/2.5/weather?id=617239&mode=xml&units=metric&type=like&APPID=1b9b3c3931a1d8b0be0ca6f725fd0388";
    }
}
