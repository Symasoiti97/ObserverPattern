using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ObserverPattern.API.ApiOWM
{
    //[Serializable]
    public class Weather
    {
        //[XmlAttribute(AttributeName = "value")]
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        //[XmlElement("humidity")]
        //[XmlAttribute(AttributeName = "value")]
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        //[XmlElement("pressure")]
        //[XmlAttribute(AttributeName = "value")]
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
    }
}
