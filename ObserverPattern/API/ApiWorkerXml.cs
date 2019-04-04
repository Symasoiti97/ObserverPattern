using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObserverPattern.API
{
    class ApiWorkerXml<T> : ApiWorker<T> where T : class
    {
        private IApiXml<T> _apiXml;

        public override event Action<object, T> EventStart;
        public override event Action<object> EventAbort;

        public ApiWorkerXml(IApiXml<T> api, IApiSetting apiSetting) : base(apiSetting)
        {
            _apiXml = api;
        }

        #region[WorkerXml]
        protected sealed override async Task Worker()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                while (_isActive)
                {
                    var reader = await webClient.DownloadStringTaskAsync(_apiSetting.Url);

                    XDocument xDocument = XDocument.Parse(reader);

                    var list = _apiXml.GetXml(xDocument);

                    EventStart?.Invoke(this, list);
                    
                    await Task.Delay(300000);
                }

                EventAbort?.Invoke(this);
            }

            
        }
        #endregion
    }
}
