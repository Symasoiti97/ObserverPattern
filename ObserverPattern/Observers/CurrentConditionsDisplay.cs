using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class CurrentConditionsDisplay : IObserver, IDisplay
    {
        public delegate void ConditionsState(WeatherData weatherData);
        public event ConditionsState ConditionsUpdate;

        private double temperature;
        private double humidity;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Update(IObserver observer)
        {
            
            this.temperature = ;
            this.humidity = humidity;
            this.Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions: {this.temperature}C degrees and {this.humidity} % humidity");
        }
    }
}
