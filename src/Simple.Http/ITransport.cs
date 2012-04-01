namespace Simple.Http
{
    public interface ITransport
    {
        IServiceResponse Send(IServiceRequest request);
        IServiceRequest CreateRequest();
    }
}
