using Newtonsoft.Json.Linq;
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
    abstract class ApiWorker<T> where T : class
    {
        protected IApiSetting _apiSetting;

        private CancellationTokenSource token;

        protected bool _isActive = false;

        public abstract event Action<T> EventStart;
        public abstract event Action EventAbort;

        public ApiWorker(IApiSetting apiSetting)
        {
            this._apiSetting = apiSetting;
        }

        public void Start()
        {
            _isActive = true;
            token = new CancellationTokenSource();
            Worker(token.Token);
            _isActive = false;
        }

        public void Abort()
        {
            _isActive = false;
            token?.Cancel();
        }

        protected abstract Task Worker(CancellationToken token);
    }
}
