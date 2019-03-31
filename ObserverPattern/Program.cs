using System;
using ObserverPattern.Pars;
using ObserverPattern.Pars.ParsSite;
using ObserverPattern.Pars.ParserNewsRambler;
using System.Xml;
using System.ServiceModel.Syndication;
using ObserverPattern.Pars.ParserWeather;
using System.Collections.Generic;
//using ObserverPattern.Pars.ParserWeather.YandexWeather;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Habr();
            //program.NewsRambler();
            program.YandexWeather();

            #region
            //WeatherData weatherData = new WeatherData();
            //CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();
            //weatherData.RegisterObserver(currentDisplay);
            //weatherData.SetMeasurements(80, 65, 30.4);
            //weatherData.RemoveObserver(currentDisplay);
            //weatherData.SetMeasurements(78, 90, 29.2);
            #endregion
            Console.ReadKey();
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            for (int i = 0; i < arg2.Length; i++)
            {
                Console.WriteLine(arg2[i]);
                AllNews(arg2[i]);
            }
        }

        private void Parser_OnNewDataWeather(object arg1, List<Weather> arg2)
        {
            for (int i = 0; i < arg2.Count; i++)
            {
                Console.WriteLine($"{arg2[i].Temperature} - {arg2[i].TimeOfDay}");
            }
        }

        private void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("Abort");
        }

        private void Habr()
        {
            ParserWorker<string[]> parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;

            parser.ParserSettings = new HabraSettings();
            parser.Start();
        }

        private void NewsRambler()
        {
            ParserWorker<string[]> parser = new ParserWorker<string[]>(new NewsRamblerParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;

            parser.ParserSettings = new NewsRamblerSettings();
            parser.Start();
        }

        private void YandexWeather()
        {
            ParserWorker<List<Weather>> parser = new ParserWorker<List<Weather>>(new YandexWeatherParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewDataWeather;

            parser.ParserSettings = new YandexWeatherSetting();
            parser.Start();
        }

        public void AllNews(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine($"{item.Title.Text}");
                    Console.WriteLine($"{item.PublishDate}");
                    Console.WriteLine($"{item.Summary.Text}");
                }
            }
        }
    }
}
