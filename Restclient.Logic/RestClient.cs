using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restclient.Logic
{
    public class RestClient : IRestClient
    {
        #region Properties

        private readonly HttpClient _client;

        public RestClient()
        {
            _client = new HttpClient();
        }

        #endregion

        #region Get

        public async Task<RestClientResponse<T>> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ? default : await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK
                    ? await response.Content.ReadAsAsync<object>()
                    : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> GetAsync<T>(string url, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0) throw new ArgumentException("No se especificó el header");

            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var response = await _client.GetAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> GetAsync<T>(string url, string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _client.GetAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        #endregion

        #region Post
        
        public async Task<RestClientResponse<T>> PostAsync<T>(string url, object @object)
        {
            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };

            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> PostAsync<T>(string url, object @object, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0) throw new ArgumentException("No se especificó el header");

            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };

            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> PostAsync<T>(string url, object @object, string token)
        {
            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };

            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        #endregion

        #region Put

        public async Task<RestClientResponse<T>> PutAsync<T>(string url, object @object)
        {
            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(url)
            };

            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> PutAsync<T>(string url, object @object, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0) throw new ArgumentException("No se especificó el header");

            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(url)
            };

            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> PutAsync<T>(string url, object @object, string token)
        {
            var message = new HttpRequestMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(@object), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(url)
            };

            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.SendAsync(message);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        #endregion

        #region Delete

        public async Task<RestClientResponse<T>> DeleteAsync<T>(string url)
        {
            var response = await _client.DeleteAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ? default : await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK
                    ? await response.Content.ReadAsAsync<object>()
                    : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> DeleteAsync<T>(string url, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0) throw new ArgumentException("No se especificó el header");

            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var response = await _client.DeleteAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        public async Task<RestClientResponse<T>> DeleteAsync<T>(string url, string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _client.DeleteAsync(url);
            _client.Dispose();

            var restClientResponse = new RestClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase,
                Response = response.StatusCode != HttpStatusCode.OK ?
                    default :
                    await response.Content.ReadAsAsync<T>(),
                Error = response.StatusCode != HttpStatusCode.OK ?
                    await response.Content.ReadAsAsync<object>() : default
            };

            return restClientResponse;
        }

        #endregion
    }
}
