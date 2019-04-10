using ObserverPattern.API;
using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    class WeatherData : ISubject
    {
        private readonly ApiWorker<Weather> _apiWorker;
        private List<IObserver> _observers;
        private Weather _weather;

        public WeatherData()
        {
            _observers = new List<IObserver>();
            _weather = new Weather();
        }

        public WeatherData(ApiWorker<Weather> apiWorker)
        {
            _observers = new List<IObserver>();
            _apiWorker = apiWorker;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void SetMeasurements(Weather weather)
        {
            _weather = weather;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_weather);
            }
        }

        public void StartParse()
        {
            _apiWorker.EventStart += Show;

            _apiWorker.Start();
        }

        private void Show(Weather weather)
        {
            SetMeasurements(weather);
        }
    }
}
