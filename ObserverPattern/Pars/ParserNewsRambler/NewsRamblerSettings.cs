using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace ObserverPattern.Pars.ParserNewsRambler
{
    public class NewsRamblerSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://news.rambler.ru/";

        public NewsRamblerSettings()
        {

        }
    }
}