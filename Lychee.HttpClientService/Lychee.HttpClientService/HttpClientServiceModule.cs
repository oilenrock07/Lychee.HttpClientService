using SimpleInjector;

namespace Lychee.HttpClientService
{
    public class HttpClientServiceModule
    {
        public void Register(Container container)
        {
            container.RegisterSingleton<IHttpClientProvider, HttpClientProvider>();
            container.RegisterSingleton<IHttpClientService, HttpClientService>();
        }
    }
}
