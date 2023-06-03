using Application.Boundaries;
using Application.Services;

namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetExchangeRatesUseCase : IGetExchangeRatesUseCase
    {
        private readonly IOutputPort<GetExchangeRatesOutput> _outputPort;
        private readonly ICurrencyRatesService _currencyRatesService;

        public GetExchangeRatesUseCase(IOutputPort<GetExchangeRatesOutput> outputPort,
            ICurrencyRatesService currencyRatesService)
        {
            _outputPort = outputPort;
            _currencyRatesService = currencyRatesService;
        }
        public async Task Execute(GetExchangeRatesUseCaseInput input)
        {
            var latestRates = await _currencyRatesService.GetLatestRates(input.CurrencyFrom, input.CurrenciesTo);
            if (latestRates == null || latestRates.Success == false)
            {
                _outputPort.NotFound("Currency rates Not Found. Check entered currencies symbols are correct.");
                return;
            }

            _outputPort.Standard(new GetExchangeRatesOutput(latestRates));
        }
    }
}
