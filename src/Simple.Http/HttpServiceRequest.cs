namespace Simple.Http
{
    public class HttpServiceRequest : IServiceRequest
    {
        public string HttpMethod { get; set; }

        public string QueryString { get; set; }
    }
}
