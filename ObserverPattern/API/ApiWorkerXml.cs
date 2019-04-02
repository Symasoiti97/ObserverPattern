﻿using System;
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
        private IApiXml<T> apiXml;

        public event Action<object, T> EventStart;
        public event Action<object> EventAbort;

        public ApiWorkerXml(IApiXml<T> api, IApiSetting apiSetting) : base(apiSetting)
        {
            this.apiXml = api;
        }

        #region[WorkerXml]
        protected sealed override async Task Worker()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                while (isActive)
                {
                    if (isActive == false)
                    {
                        return;
                    }

                    var reader = await webClient.DownloadStringTaskAsync(apiSetting.Url);

                    XDocument xDocument = XDocument.Parse(reader);

                    var list = apiXml.GetXml(xDocument);

                    EventStart?.Invoke(this, list);
                    
                    Thread.Sleep(3000);
                    //await Task.Delay(5000);
                }

                EventAbort?.Invoke(this);
            }

            
        }
        #endregion
    }
}
