using Application.Boundaries;
using Application.Services;

namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeUseCase : ISimulateTradeUseCase
    {        
        private readonly IOutputPort<SimulateTradeUseCaseOutput> _outputPort;
        private readonly ICurrencyRatesService _currencyRatesService;

        public SimulateTradeUseCase(IOutputPort<SimulateTradeUseCaseOutput> outputPort,
            ICurrencyRatesService currencyRatesService
            )
        {            
            this._outputPort = outputPort;
            this._currencyRatesService = currencyRatesService;            
        }
        public async Task Execute(SimulateTradeUseCaseInput input)
        {
            try
            {
                var latestRates = await _currencyRatesService.GetLatestRates(input.CurrencyFrom, new List<string>() { input.CurrencyTo });
                if (latestRates == null || latestRates.Success == false)
                {                    
                    _outputPort.NotFound("You have provided one or more invalid Currency Codes. [Required format: currencies=EUR,USD,GBP,...]");
                    input.ErrorOccured = true;
                    return;
                }

                decimal destinationRate = latestRates.Rates.FirstOrDefault().Value;
                decimal convertedAmount = input.Amount * destinationRate;

                _outputPort.Standard(new SimulateTradeUseCaseOutput(input.CurrencyFrom, input.CurrencyTo, input.Amount, destinationRate, convertedAmount));                
            }
            catch (Exception ex)
            {                
                _outputPort.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
