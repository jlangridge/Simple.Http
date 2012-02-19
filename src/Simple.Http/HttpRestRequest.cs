using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Http
{
    public class HttpRestRequest : IServiceRequest
    {
        public string HttpMethod { get; set; }
    }
}
