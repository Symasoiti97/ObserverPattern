using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Pars.ParsSite
{
    class SiteSettings : IParserSetting
    {

        public string BaseUrl { get; set; } = "URI";
        public string Prefix { get; set; }

        public SiteSettings()
        {
        }

     }
}
