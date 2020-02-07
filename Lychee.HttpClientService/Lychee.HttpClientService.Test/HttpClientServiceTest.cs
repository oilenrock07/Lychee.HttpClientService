using System.Collections.Generic;
using System.Net.Http;
using NUnit.Framework;

namespace Lychee.HttpClientService.Test
{
    [TestFixture]
    public class HttpClientServiceTest
    {
        [Test]
        public void TestConnectWithCookie()
        {
            //Arrange
            var httpClientProvider = new HttpClientProvider();
            var httpClientService = new HttpClientService(httpClientProvider, "https://webapi.investagrams.com/");
            var headers = new Dictionary<string, string>
            {
                {"cookie", "__cfduid=de323b9ac823cdc7f269a305c2e32b2c21564121419; _uc_referrer=https%3A//www.google.com/; _uc_initial_landing_page=https%3A//www.investagrams.com/; _ga=GA1.2.689041548.1564121423; _fbp=fb.1.1564121423362.1863262359; _uc_utm_medium=InvestaPlatform; _uc_utm_campaign=InvestaPrime; _uc_utm_term=; _uc_utm_content=; _uc_utm_source=PrimeButton; __tawkuuid=e::investagrams.com::HwBjbyfzeoyTLlvUdRt3JmaFlvO27w/60zDsTwo9mQoDq9lE47f46zld/1IMlWWr::2; _fbc=fb.1.1574068802060.IwAR3CrqMPypr465sGPAkvk4vny_cecYphhjvAcLKHt_RlAJdAJ4vrziquGCw; __gads=ID=8ae7617cb96d5b41:T=1579846771:S=ALNI_MaWEVwnz5BX6FRq7GWVmImL2zRHzg; _gid=GA1.2.1133112883.1580945880; _uc_last_referrer=direct; e7bfeae28c72f9a5fae2a6ce78db24e7=7717A7A56A01A305DF86531111B88208E8F4361BE5D6B39B9EE4550B988C2B7E6D27A06ECDBFDA39A39FFD14B1AA05C25512BFBFC57EFE9B5EC0C0030501F8528BA6673B8F17DA06AC89875539C0D577699FB5E1C4437DFF4AF2C0FBC30C8FE8C6CB06BAB7CF6810A59DEB6A92649143E353F311058852E9825B1AFE4146495721C4523F32B16E2C280462DAB580EA5A7F4EDFA10D3BD4E52D7E74F4CC23FA092C9E8FB19AD05CA9B68B257B316B7F038F405A18AA1F12F3407AD39E7F02D14AB1C5CC040613472CDAA608DEA99B7D266E3E2C76120477289AC12B828D71B1ADCC550D46EA43F39BE4ADB35B5DF0C27F; _uc_current_session=true; _uc_visits=223; _gat=1"},
                {"origin", "https://www.investagrams.com"}
            };


            //Act
            var response = httpClientService.SendRequest<InvestaViewStockResponse>("/InvestaApi/Stock/viewStock?stockCode=PSE:WEB", HttpMethod.Post, headers);

            //Asserts
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Result.StockInfo.StockCode, Is.Not.Empty);
        }
    }
}
