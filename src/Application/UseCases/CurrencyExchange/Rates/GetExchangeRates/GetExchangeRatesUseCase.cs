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
            try
            {
                var latestRates = await _currencyRatesService.GetLatestRates(input.CurrencyFrom, input.CurrenciesTo);
                if (latestRates == null || latestRates.Success == false)
                {                    
                    _outputPort.NotFound("Base currency access restricted or you have provided one or more invalid currency codes. [Required format: currencies=EUR,USD,GBP,...]");
                    input.ErrorOccured = true;
                    return;
                }

                _outputPort.Standard(new GetExchangeRatesOutput(latestRates));                
            }
            catch (Exception ex)
            {                
                _outputPort.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
