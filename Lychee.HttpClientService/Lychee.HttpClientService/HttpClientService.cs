using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lychee.HttpClientService
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientProvider _httpClientProvider;
        private HttpClient HttpClient { get; set; }

        public HttpClientService(IHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
            HttpClient = httpClientProvider.GetHttpClient();
        }


        public virtual void CreateNewHttpClient(string baseUrl)
        {
            HttpClient?.Dispose();
            HttpClient = _httpClientProvider.CreateNewHttpClient(baseUrl);
        }

        /// <summary>
        /// Send the request to the website with specific cookie or headers
        /// This can be used when hacking websites and you already have an authenticated cookie of the website
        /// </summary>
        /// <typeparam name="T">return object</typeparam>
        /// <param name="path">The remaining part of the url e.g. /InvestaApi/Stock/viewStock?stockCode=PSE:WEB</param>
        /// <param name="method">If Post or Get</param>
        /// <param name="headers">Dictionary of headers and cookies. "cookie":"value"</param>
        /// <returns></returns>
        public async Task<T> SendRequest<T>(string path, HttpMethod method,
            Dictionary<string, string> headers) where T : class
        {
            var message = new HttpRequestMessage(method, path);
            foreach (var header in headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }

            var result = await HttpClient.SendAsync(message).ConfigureAwait(false);
            var strResponse = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(strResponse);
        }
    }

    public interface IHttpClientService
    {
        Task<T> SendRequest<T>(string path, HttpMethod method,
            Dictionary<string, string> headers) where T : class;

        void CreateNewHttpClient(string baseUrl);
    }
}
