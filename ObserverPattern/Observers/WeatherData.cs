using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class WeatherData : ISubject
    {
        private List<IObserver> observers;
        private double temperature;
        private double humidity;
        private double pressure;

        public WeatherData()
        {
            this.observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObserver observer = this.observers[i];
                observer.Update(this.temperature, this.humidity, this.pressure);
            }
        }

        public void MeasurementsChange()
        {
            this.NotifyObservers();
        }

        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.MeasurementsChange();
        }
    }
}
