using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentTemperatureDisplay : IObserver, IDisplay
    {
        private double _temperature;
        private ISubject _weatherData;

        public CurrentTemperatureDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            if (_temperature != temperature)
            {
                _temperature = temperature;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current temperature: {this._temperature} C");
        }
    }
}
