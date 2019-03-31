using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace ObserverPattern.Pars.ParserNewsRambler
{
    public class YandexWeatherSetting : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://www.gismeteo.md/weather-tiraspol-4981/3-days/";//"https://yandex.ru/pogoda/tiraspol";

        public YandexWeatherSetting()
        {

        }
    }
}