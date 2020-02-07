using SimpleInjector;

namespace Lychee.HttpClientService
{
    public static class HttpClientServiceModule
    {
        public static void RegisterLycheeHttpClientService(this Container container)
        {
            container.RegisterSingleton<IHttpClientProvider, HttpClientProvider>();
            container.RegisterSingleton<IHttpClientService, HttpClientService>();
        }
    }
}
