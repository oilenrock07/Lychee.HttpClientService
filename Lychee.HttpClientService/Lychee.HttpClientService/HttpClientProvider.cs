using System.Net.Http;

namespace Lychee.HttpClientService
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;

        public virtual HttpClient GetHttpClient()
        {
            return _httpClient ?? (_httpClient = new HttpClient(GetHttpClientHandler()));
        }

        public virtual HttpClientHandler GetHttpClientHandler()
        {
            return _httpClientHandler ?? (_httpClientHandler = new HttpClientHandler {UseCookies = false});
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

        void Dispose();
    }
}
