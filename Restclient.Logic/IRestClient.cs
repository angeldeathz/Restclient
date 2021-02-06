using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restclient.Logic
{
    public interface IRestClient
    {
        Task<RestClientResponse<T>> GetAsync<T>(string url);
        Task<RestClientResponse<T>> GetAsync<T>(string url, Dictionary<string, string> headers);
        Task<RestClientResponse<T>> GetAsync<T>(string url, string token);
        Task<RestClientResponse<T>> PostAsync<T>(string url, object @object);
        Task<RestClientResponse<T>> PostAsync<T>(string url, object @object, Dictionary<string, string> headers);
        Task<RestClientResponse<T>> PostAsync<T>(string url, object @object, string token);
        Task<RestClientResponse<T>> PutAsync<T>(string url, object @object);
        Task<RestClientResponse<T>> PutAsync<T>(string url, object @object, Dictionary<string, string> headers);
        Task<RestClientResponse<T>> PutAsync<T>(string url, object @object, string token);
        Task<RestClientResponse<T>> DeleteAsync<T>(string url);
        Task<RestClientResponse<T>> DeleteAsync<T>(string url, Dictionary<string, string> headers);
        Task<RestClientResponse<T>> DeleteAsync<T>(string url, string token);
    }
}
