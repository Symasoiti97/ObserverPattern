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

        protected bool _isActive = false;

        public abstract event Action<object, T> EventStart;
        public abstract event Action<object> EventAbort;

        public ApiWorker(IApiSetting apiSetting)
        {
            this._apiSetting = apiSetting;
        }

        public void Start()
        {
            if (_isActive == false)
            {
                _isActive = true;
                Worker();
            }
        }

        public void Abort()
        {
            _isActive = false;
            Thread.Sleep(300001);
        }

        protected abstract Task Worker();
    }
}
