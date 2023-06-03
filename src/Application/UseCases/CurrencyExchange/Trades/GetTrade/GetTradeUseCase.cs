using Application.Boundaries;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrade
{
    public class GetTradeUseCase : IGetTradeUseCase
    {
        private readonly IOutputPort<GetTradeUseCaseOutput> _outputPort;
        private readonly ILogger<GetTradeUseCase> _logger;
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;

        public GetTradeUseCase(IOutputPort<GetTradeUseCaseOutput> outputPort,
            ILogger<GetTradeUseCase> logger,
            ICurrencyExchangeTradeQueryRepository queryRepository)
        {
            this._outputPort = outputPort;
            this._logger = logger;
            this._queryRepository = queryRepository;
        }
        public async Task Execute(GetTradeUseCaseInput input)
        {
            try
            {
                var exchangeTrade = await _queryRepository.GetByIdAsync(input.Id);                
                _outputPort.Standard(new GetTradeUseCaseOutput(exchangeTrade));
                _logger.LogInformation("GetTradeUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the GetTradeUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the GetTradeUseCase: {ex.Message}");
            }
        }
    }
}
