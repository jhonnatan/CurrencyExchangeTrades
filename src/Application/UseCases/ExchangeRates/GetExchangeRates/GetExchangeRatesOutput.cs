using Domain.ExchangeRates.Dtos;

namespace Application.UseCases.ExchangeRates.GetExchangeRates
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
