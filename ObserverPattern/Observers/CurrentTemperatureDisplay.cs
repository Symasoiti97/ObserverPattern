using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentTemperatureDisplay : IObserver, IDisplay
    {
        private double temperature;
        private ISubject weatherData;

        public CurrentTemperatureDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            //if (this.temperature != temperature)
            {
                this.temperature = temperature;
                this.Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current temperature: {this.temperature} C");
        }
    }
}
