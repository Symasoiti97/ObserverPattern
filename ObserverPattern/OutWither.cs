using ObserverPattern.API;
using ObserverPattern.API.ApiOWM;
using ObserverPattern.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class OutWither
    {
        private WeatherData _weatherData;

        public OutWither()
        {
            _weatherData = new WeatherData();
        }

        public void Go()
        {
            CurrentTemperatureDisplay currentTemperatureDisplay = new CurrentTemperatureDisplay(_weatherData);
            CurrentHumidityDisplay currentHumidityDisplay = new CurrentHumidityDisplay(_weatherData);
            CurrentPressureDisplay currentPressureDisplay = new CurrentPressureDisplay(_weatherData);

            ApiWorker<Weather> apiWorker = new ApiWorker<Weather>(new ApiWeatherXml(), new WeatherOWMSetting());
            apiWorker.EventStart += Show;
            apiWorker.EventAbort += ShowAbort;

            apiWorker.Start();
        }

        private void Show(Weather weather)
        {
                _weatherData.SetMeasurements(Convert.ToDouble(weather.Temperature.Replace('.', ',')),
                    Convert.ToDouble(weather.Humidity.Replace('.', ',')),
                    Convert.ToDouble(weather.Pressure.Replace('.', ',')));
        }

        private static void ShowAbort()
        {
            Console.WriteLine("Abort");
        }
    }
}
