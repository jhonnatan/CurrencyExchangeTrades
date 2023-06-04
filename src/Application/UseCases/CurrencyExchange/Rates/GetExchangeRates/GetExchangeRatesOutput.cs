using Domain.Dtos;

namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetExchangeRatesOutput
    {
        public LatestRatesResponse LatestRates { get; private set; }

        public GetExchangeRatesOutput(LatestRatesResponse latestRates)
        {
            LatestRates = latestRates;
        }
    }
}
