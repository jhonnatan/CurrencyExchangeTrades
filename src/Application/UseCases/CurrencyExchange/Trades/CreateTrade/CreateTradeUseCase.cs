using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCase : ICreateTradeUseCase
    {
        private readonly CheckClientTradesLimitHandler _checkClientTradesLimitHandler;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;
        private readonly ILogger<CreateTradeUseCase> _logger;

        public CreateTradeUseCase(
            CheckClientTradesLimitHandler checkClientTradesLimitHandler,
            GetLatestRateHandler getLatestRateHandler,
            SaveExchangeTradeHandler saveExchangeTradeHandler,
            IOutputPort<CreateTradeUseCaseOutput> outputPort,
            ILogger<CreateTradeUseCase> logger)
        {
            _checkClientTradesLimitHandler = checkClientTradesLimitHandler;
            _outputPort = outputPort;
            _logger = logger;
            // configure handlers sequence: CheckClientTradesLimitHandler -> GetLatestRateHandler -> SaveExchangeTradeHandler
            _checkClientTradesLimitHandler.SetSucessor(getLatestRateHandler);
            getLatestRateHandler.SetSucessor(saveExchangeTradeHandler);
        }

        public async Task Execute(CreateTradeUseCaseInput input)
        {
            try
            {
                await _checkClientTradesLimitHandler.ProcessRequest(input);

                if (input.ErrorOccured)
                    return;

                _outputPort.Standard(new CreateTradeUseCaseOutput(input.CurrencyExchangeTrade));
                _logger.LogInformation("CreateTradeUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the CreateTradeUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the CreateTradeUseCase: {ex.Message}");
            }
        }       
    }
}
