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
        private List<IObserver> _observers;
        private ApiWorker<Weather> _apiWorker;
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
            Start();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void SetMeasurements(Weather weather)
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

        private void Start()
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
