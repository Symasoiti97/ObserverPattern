using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ObserverPattern.API
{
    class ApiWeatherXml : IApi<Weather>
    {
        public Weather Parse(string reader)
        {
            XDocument xDocument = XDocument.Parse(reader);

            var weather = xDocument.Element("current");

            #region[XmlSerializer]
            //var serializer = new XmlSerializer(typeof(Weather));
            //XmlReader read = weather.CreateReader();
            //Weather myObject = (Weather)serializer.Deserialize(read);
            //read.Close();
            //Console.WriteLine(myObject.Pressure);

            //return myObject;
            #endregion

            NumberFormatInfo numberFormat = new NumberFormatInfo();

            return new Weather
            {
                Temperature = Convert.ToDouble(weather.Element("temperature").Attribute("value").Value, numberFormat),
                Humidity = Convert.ToDouble(weather.Element("humidity").Attribute("value").Value, numberFormat),
                Pressure = Convert.ToDouble(weather.Element("pressure").Attribute("value").Value, numberFormat)
            };
        }
    }
}
