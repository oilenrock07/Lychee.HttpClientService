using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lychee.HttpClientService
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient HttpClient { get; }

        public HttpClientService(IHttpClientProvider httpClientProvider)
        {
            HttpClient = httpClientProvider.GetHttpClient();
        }

        /// <summary>
        /// Send the request to the website with specific cookie or headers
        /// This can be used when hacking websites and you already have an authenticated cookie of the website
        /// </summary>
        /// <typeparam name="T">return object</typeparam>
        /// <param name="baseUrl">Base url of the website. e.g. https://webapi.investagrams.com</param>
        /// <param name="path">The remaining part of the url e.g. /InvestaApi/Stock/viewStock?stockCode=PSE:WEB</param>
        /// <param name="method">If Post or Get</param>
        /// <param name="headers">Dictionary of headers and cookies. "cookie":"value"</param>
        /// <returns></returns>
        public async Task<T> SendRequest<T>(string baseUrl, string path, HttpMethod method,
            Dictionary<string, string> headers) where T : class
        {
            HttpClient.BaseAddress = new Uri(baseUrl);
            var message = new HttpRequestMessage(method, path);
            foreach (var header in headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }

            var result = await HttpClient.SendAsync(message);
            var strResponse = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(strResponse);
        }
    }

    public interface IHttpClientService
    {
        Task<T> SendRequest<T>(string baseUrl, string path, HttpMethod method,
            Dictionary<string, string> headers) where T : class;
    }
}
