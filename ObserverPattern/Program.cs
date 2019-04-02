using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.API;
using ObserverPattern.API.ApiOWM;
using ObserverPattern.Observers;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            new OutWither().Go();

            Console.ReadKey();
        }
    }
}
