using System.Dynamic;

namespace Simple.Http
{
    public static class Service 
    {
        public static dynamic At(string url)
        {
            return new MethodDispatcher(new HttpTransport(url));
        }
    }
}
