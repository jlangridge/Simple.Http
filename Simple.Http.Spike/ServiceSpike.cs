using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Http.Spike
{
    public class ServiceSpike
    {
        public ServiceSpike()
        {
            Dispatcher = new DynamicDispatcher();
        }

        public dynamic Dispatcher { get; set; }
    }
}
