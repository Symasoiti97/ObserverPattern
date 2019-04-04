using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.API
{
    class ApiWorkerJson<T> : ApiWorker<T> where T : class
    {
        private IApiJson<T> _apiJson;

        public override event Action<object, T> EventStart;
        public override event Action<object> EventAbort;

        public ApiWorkerJson(IApiJson<T> apiJson, IApiSetting apiSetting) : base(apiSetting)
        {
            _apiJson = apiJson;
            apiSetting.Url = "http://api.openweathermap.org/data/2.5/weather?id=617239&units=metric&type=like&APPID=1b9b3c3931a1d8b0be0ca6f725fd0388";
        }

        #region[WorkerJson]
        protected override async Task Worker()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                while (_isActive)
                {
                    var reader = await webClient.DownloadStringTaskAsync(_apiSetting.Url);

                    JObject json = JObject.Parse(reader);

                    var list = _apiJson.GetJson(json);

                    EventStart?.Invoke(this, list);

                    await Task.Delay(300000);
                }
            }

            EventAbort?.Invoke(this);
        }
        #endregion
    }
}
