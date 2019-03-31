using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Pars
{
    interface IParserSetting
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
    }
}
