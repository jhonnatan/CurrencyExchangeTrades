using Application.Boundaries;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeUseCase : ISimulateTradeUseCase
    {
        private readonly ILogger<SimulateTradeUseCase> _logger;
        private readonly IOutputPort<SimulateTradeUseCaseOutput> _outputPort;
        private readonly ICurrencyRatesService _currencyRatesService;

        public SimulateTradeUseCase(ILogger<SimulateTradeUseCase> logger,
            IOutputPort<SimulateTradeUseCaseOutput> outputPort,
            ICurrencyRatesService currencyRatesService
            )
        {
            this._logger = logger;
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
                    _outputPort.NotFound("Currency rates Not Found. Check entered currencies symbols are correct.");
                    return;
                }

                decimal destinationRate = latestRates.Rates.FirstOrDefault().Value;
                decimal convertedAmount = destinationRate / input.Amount;

                _outputPort.Standard(new SimulateTradeUseCaseOutput(convertedAmount));
                _logger.LogInformation("SimulateTradeUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the SimulateTradeUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the SimulateTradeUseCase: {ex.Message}");
            }
        }
    }
}
