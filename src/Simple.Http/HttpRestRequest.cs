namespace Simple.Http
{
    public class HttpRestRequest : IServiceRequest
    {
        public string HttpMethod { get; set; }

        public string QueryString { get; set; }
    }
}
