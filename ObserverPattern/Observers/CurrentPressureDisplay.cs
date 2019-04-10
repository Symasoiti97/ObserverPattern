using ObserverPattern.API.ApiOWM;
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

        public void Update(Weather weather)
        {
            if (_pressure != weather.Pressure)
            {
                _pressure = weather.Pressure;
                Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current pressure: {this._pressure} hpa");
        }
    }
}
