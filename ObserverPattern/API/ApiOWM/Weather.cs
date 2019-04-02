using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.API.ApiOWM
{
    class Weather
    {
        public string Temperature { get; set; } = "";
        public string Humidity { get; set; } = "";
        public string Pressure { get; set; } = "";
    }
}
