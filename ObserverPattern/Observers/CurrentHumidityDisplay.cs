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

        public void Update(double temperature, double humidity, double pressure)
        {
            if (_humidity != humidity)
            {
                _humidity = humidity;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current humidity: {this._humidity} % ");
        }
    }
}
