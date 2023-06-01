using Domain.ExchangeRates.Dtos;

namespace WebApi.Controllers.ExchangeRates.GetExchangeRate
{
    public class ExchangeRatesResponse
    {
        public LatestRates LatestRates { get; private set; }

        public ExchangeRatesResponse(LatestRates latestRates)
        {
            LatestRates = latestRates;
        }
    }
}