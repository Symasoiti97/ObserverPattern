using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentConditionsDisplay : IObserver, IDisplay
    {
        private double temperature;
        private double humidity;
        private ISubject weatherData;

        public CurrentConditionsDisplay()
        {

        }

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions: {this.temperature}C degrees and {this.humidity} % humidity");
        }
    }
}
