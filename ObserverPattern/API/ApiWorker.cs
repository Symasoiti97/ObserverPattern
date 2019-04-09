﻿using Newtonsoft.Json.Linq;
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
    class ApiWorker<T> where T : class
    {
        private IApiSetting _apiSetting;
        private IApi<T> _api;

        private CancellationTokenSource token;

        private bool _isActive = false;

        public event Action<T> EventStart;
        public event Action EventAbort;

        public ApiWorker(IApi<T> api, IApiSetting apiSetting)
        {
            _api = api;
            _apiSetting = apiSetting;
        }

        public void Start()
        {
            _isActive = true;
            token = new CancellationTokenSource();
            Task.Run(() => Worker(token.Token));
        }

        public void Abort()
        {
            _isActive = false;
            token?.Cancel();
        }

        private async Task Worker(CancellationToken token)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                while (_isActive)
                {
                    var reader = await webClient.DownloadStringTaskAsync(_apiSetting.Url);

                    var list = _api.Parse(reader);

                    EventStart?.Invoke(list);

                    try
                    {
                        await Task.Delay(300000, token);
                    }
                    catch (OperationCanceledException ex)
                    {
                    }
                }
            }

            EventAbort?.Invoke();
        }
    }
}
