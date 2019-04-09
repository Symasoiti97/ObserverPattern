using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ObserverPattern.API;
using ObserverPattern.API.ApiOWM;
using ObserverPattern.Observers;

namespace ObserverPattern
{
    //[Serializable]
    //public class SomeTest
    //{
    //    public string BinaryTest { get; set; }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        XDocument document = new XDocument(
    //            new XElement("Weather",
    //                new XElement("pressure", "100")));

    //       var serializer = new XmlSerializer(typeof(Weather));
    //        XmlReader reader = document.CreateReader();
    //        Weather myObject = (Weather)serializer.Deserialize(reader);
    //        reader.Close();

    //        Console.WriteLine(myObject.Pressure);
    //        Console.ReadKey(true);
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            new OutWither().Go();

            Console.ReadKey();
        }
    }
}
