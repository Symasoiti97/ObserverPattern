using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ObserverPattern.API;
using ObserverPattern.API.ApiOWM;
using ObserverPattern.Observers;
using System.Configuration;
using System.Collections.Specialized;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ConfigurationManager.AppSettings.Get("XmlOWN");

            ApiWorker<Weather> apiWorker = new ApiWorker<Weather>(new ApiWeatherXml(), new WeatherOWMSetting(url));

            WeatherData weatherData = new WeatherData(apiWorker);

            IObserver currentHumidity = new CurrentHumidityDisplay(weatherData);
            IObserver currentPressure = new CurrentPressureDisplay(weatherData);
            IObserver currentTemperature = new CurrentTemperatureDisplay(weatherData);

            Console.ReadKey();
        }
    }
}
