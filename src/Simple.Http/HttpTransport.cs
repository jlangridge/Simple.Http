using System;

namespace Simple.Http
{
    public class HttpTransport : ITransport
    {
        public string Url { get; private set; }

        public HttpTransport(string url)
        {
            Url = url;
        }

        public IServiceResponse Send(IServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public IServiceRequest CreateRequest()
        {
            throw new NotImplementedException();
        }
    }
}
