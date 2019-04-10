using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.API.ApiOWM
{
    class WeatherOWMSetting : IApiSetting
    {
        public string Url { get; }

        public WeatherOWMSetting(string url)
        {
            Url = url;
        }
    }
}
