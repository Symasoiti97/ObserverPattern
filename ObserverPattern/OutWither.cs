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

            ApiWorker<Weather> apiWorkerXml = new ApiWorkerXml<Weather>(new WeatherOWM(), new WeatherOWMSetting());
            apiWorkerXml.EventStart += Show;
            apiWorkerXml.EventAbort += ShowAbort;
            apiWorkerXml.Start();
            Console.WriteLine("Start Abort()");
            Thread.Sleep(4000);
            apiWorkerXml.Abort();
            Console.WriteLine("End Abort()!");

            #region[ApiWorkerJson]
            //ApiWorker<Weather> apiWorkerJson = new ApiWorkerJson<Weather>(new WeatherOWM(), new WeatherOWMSetting());
            //apiWorkerJson.EventStart += Show;
            //apiWorkerJson.EventAbort += ShowAbort;
            //apiWorkerJson.Start();
            #endregion
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
