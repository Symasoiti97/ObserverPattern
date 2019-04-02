using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentPressureDisplay : IObserver, IDisplay
    {
        private double pressure;
        private ISubject weatherData;

        public CurrentPressureDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            if (this.pressure != pressure)
            {
                this.pressure = pressure;
                this.Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current pressure: {this.pressure} hpa");
        }
    }
}
