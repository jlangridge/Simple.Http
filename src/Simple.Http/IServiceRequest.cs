namespace Simple.Http
{
    public interface IServiceRequest
    {
        string HttpMethod { get; set; }
        string QueryString { get; set; }
    }
}