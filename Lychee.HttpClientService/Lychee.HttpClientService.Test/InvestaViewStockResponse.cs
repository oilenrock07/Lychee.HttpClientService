using Lychee.HttpClientService.Test.Investagrams;

namespace Lychee.HttpClientService.Test
{
    public class InvestaViewStockResponse : InvestaBaseApiResponse
    {
        public StockInfo StockInfo { get; set; }
    }
}
