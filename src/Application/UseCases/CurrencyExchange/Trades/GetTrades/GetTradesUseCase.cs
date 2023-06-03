using Application.Boundaries;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrades
{
    public class GetTradesUseCase : IGetTradesUseCase
    {
        private readonly IOutputPort<GetTradesUseCaseOutput> _outputPort;
        private readonly ILogger<GetTradesUseCase> _logger;
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;

        public GetTradesUseCase(IOutputPort<GetTradesUseCaseOutput> outputPort,
            ILogger<GetTradesUseCase> logger,
            ICurrencyExchangeTradeQueryRepository queryRepository)
        {
            this._outputPort = outputPort;
            this._logger = logger;
            this._queryRepository = queryRepository;
        }
        public async Task Execute(GetTradesUseCaseInput input)
        {
            try
            {
                var exchangeTrades = await _queryRepository.GetExchangeTradesByClientIdAsync(input.ClientId);
                _outputPort.Standard(new GetTradesUseCaseOutput(exchangeTrades.ToList()));
                _logger.LogInformation("GetTradesUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the GetTradesUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the GetTradesUseCase: {ex.Message}");
            }
        }
    }
}
