using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentPressureDisplay : IObserver, IDisplay
    {
        private double _pressure;
        private ISubject _weatherData;

        public CurrentPressureDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            if (_pressure != pressure)
            {
                _pressure = pressure;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current pressure: {this._pressure} hpa");
        }
    }
}
