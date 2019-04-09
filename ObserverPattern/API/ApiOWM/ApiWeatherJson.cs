using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObserverPattern.API.ApiOWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;


namespace ObserverPattern.API
{
    class ApiWeatherJson : IApi<Weather>
    {
        public Weather Parse(string reader)
        {
            JObject json = JObject.Parse(reader);

            var weatherArray = json["main"].ToString();
            
            return JsonConvert.DeserializeObject<Weather>(weatherArray);
        }
    }
}
