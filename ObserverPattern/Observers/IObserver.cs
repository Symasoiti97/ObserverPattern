using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observers
{
    interface IObserver
    {
        void Update(double temperature, double humidity, double pressure);
    }
}
