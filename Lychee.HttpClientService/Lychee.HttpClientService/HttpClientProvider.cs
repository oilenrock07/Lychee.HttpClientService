using System;
using System.Net.Http;

namespace Lychee.HttpClientService
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;

        private readonly string _baseUrl;

        public HttpClientProvider(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public virtual HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                CreateNewHttpClient(_baseUrl);

            return _httpClient;
        }

        public virtual HttpClientHandler GetHttpClientHandler()
        {
            return _httpClientHandler ?? (_httpClientHandler = new HttpClientHandler {UseCookies = false});
        }

        public virtual HttpClient CreateNewHttpClient(string baseUrl)
        {
            _httpClient?.Dispose();
            return _httpClient = new HttpClient(GetHttpClientHandler()) { BaseAddress = new Uri(_baseUrl) };
        }

        public virtual void Dispose()
        {
            _httpClient?.Dispose();
            _httpClientHandler.Dispose();
        }
    }

    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient();

        HttpClientHandler GetHttpClientHandler();
        HttpClient CreateNewHttpClient(string baseUrl);

        void Dispose();
    }
}
