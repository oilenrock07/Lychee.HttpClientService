using SimpleInjector;

namespace Lychee.HttpClientService
{
    public static class HttpClientServiceModule
    {
        public static void RegisterLycheeHttpClientService(this Container container)
        {
            container.RegisterSingleton<IHttpClientService, HttpClientService>();
        }

        public static void RegisterLycheeHttpClientService(this Container container, string baseUrl)
        {
            container.RegisterSingleton<IHttpClientProvider>(() => new HttpClientProvider(baseUrl));
            container.RegisterSingleton<IHttpClientService, HttpClientService>();
        }
    }
}
