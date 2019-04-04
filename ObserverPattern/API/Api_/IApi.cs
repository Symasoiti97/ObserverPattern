using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.API
{
    interface IApi<T> where T : class
    {
        T GetApi();
    }
}
