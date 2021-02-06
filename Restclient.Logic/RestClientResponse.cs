using System.Net;

namespace Restclient.Logic
{
    public class RestClientResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
        public object Error { get; set; }
    }
}
