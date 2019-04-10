using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentHumidityDisplay : IObserver, IDisplay
    {
        private double _humidity;
        private ISubject _weatherData;

        public CurrentHumidityDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(Weather weather)
        {
            if (_humidity != weather.Humidity)
            {
                _humidity = weather.Humidity;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current humidity: {this._humidity} % ");
        }
    }
}
