using Domain.CurrencyExchange.Rates.Dtos;

namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetExchangeRatesOutput
    {
        public LatestRates LatestRates { get; private set; }

        public GetExchangeRatesOutput(LatestRates latestRates)
        {
            LatestRates = latestRates;
        }
    }
}
