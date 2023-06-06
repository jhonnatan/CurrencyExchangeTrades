using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCase : ICreateTradeUseCase
    {
        private readonly CheckClientTradesLimitHandler _checkClientTradesLimitHandler;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;        

        public CreateTradeUseCase(
            CheckClientTradesLimitHandler checkClientTradesLimitHandler,
            GetLatestRateHandler getLatestRateHandler,
            SaveExchangeTradeHandler saveExchangeTradeHandler,
            IOutputPort<CreateTradeUseCaseOutput> outputPort)
        {
            _checkClientTradesLimitHandler = checkClientTradesLimitHandler;
            _outputPort = outputPort;            
            // Configure handlers sequence: CheckClientTradesLimitHandler -> GetLatestRateHandler -> SaveExchangeTradeHandler
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
            }
            catch (Exception ex)
            {                
                _outputPort.Error($"An error occurred in the CreateTradeUseCase: {ex.Message}", ex.StackTrace);
            }
        }       
    }
}
