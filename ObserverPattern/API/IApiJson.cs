using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObserverPattern.API
{
    interface IApiJson<T> where T : class
    {
        T GetJson(JObject json);
    }
}
