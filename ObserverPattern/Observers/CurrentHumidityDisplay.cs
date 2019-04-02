using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentHumidityDisplay : IObserver, IDisplay
    {
        private double humidity;
        private ISubject weatherData;

        public CurrentHumidityDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            if (this.humidity != humidity)
            {
                this.humidity = humidity;
                this.Display();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Current humidity: {this.humidity} % ");
        }
    }
}
