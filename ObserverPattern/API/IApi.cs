﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern.API
{
    interface IApi<T>
    {
        T Parse(string reader);
    }
}