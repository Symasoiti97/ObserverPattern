using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Pars.ParsSite
{
    class HabraSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://habr.com/ru/";

        public HabraSettings()
        {

        }
     }
}
