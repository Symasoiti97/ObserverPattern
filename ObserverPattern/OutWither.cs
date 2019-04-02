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
        WeatherData weatherData;

        public OutWither()
        {
            this.weatherData = new WeatherData();
        }

        public void Go()
        {
            CurrentTemperatureDisplay currentTemperatureDisplay = new CurrentTemperatureDisplay(weatherData);
            CurrentHumidityDisplay currentHumidityDisplay = new CurrentHumidityDisplay(weatherData);
            CurrentPressureDisplay currentPressureDisplay = new CurrentPressureDisplay(weatherData);

            ApiWorkerXml<Weather> apiWorkerXml = new ApiWorkerXml<Weather>(new WeatherOWM(), new WeatherOWMSetting());
            apiWorkerXml.EventStart += Show;
            apiWorkerXml.EventAbort += ShowAbort;
            apiWorkerXml.Start();
            apiWorkerXml.Abort();
            //Thread.Sleep(10000);
            //apiWorkerXml.Start();

            #region[ApiWorkerJson]
            //ApiWorkerJson<Weather> apiWorkerJson = new ApiWorkerJson<Weather>(new WeatherOWM(), new WeatherOWMSetting());
            //apiWorkerJson.EventStart += Show;
            //apiWorkerJson.EventAbort += ShowAbort;
            //apiWorkerJson.Start();
            #endregion
        }

        private void Show(object obj, Weather weather)
        {
                weatherData.SetMeasurements(Convert.ToDouble(weather.Temperature.Replace('.', ',')),
                    Convert.ToDouble(weather.Humidity.Replace('.', ',')),
                    Convert.ToDouble(weather.Pressure.Replace('.', ',')));
        }

        private static void ShowAbort(object obj)
        {
            Console.WriteLine("Abort");
        }
    }
}
