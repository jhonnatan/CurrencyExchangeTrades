using Application.Boundaries;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.GetAllTrades
{
    public class GetAllTradesUseCase : IGetAllTradesUseCase
    {
        private readonly IOutputPort<GetAllTradesUseCaseOutput> _outputPort;
        private readonly ILogger<GetAllTradesUseCase> _logger;
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;

        public GetAllTradesUseCase(IOutputPort<GetAllTradesUseCaseOutput> outputPort,
            ILogger<GetAllTradesUseCase> logger,
            ICurrencyExchangeTradeQueryRepository queryRepository)
        {
            this._outputPort = outputPort;
            this._logger = logger;
            this._queryRepository = queryRepository;
        }
        public async Task Execute()
        {
            try
            {
                var exchangeTrades = await _queryRepository.GetAllAsync();
                _outputPort.Standard(new GetAllTradesUseCaseOutput(exchangeTrades.ToList()));
                _logger.LogInformation("GetAllTradesUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the GetAllTradesUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the GetAllTradesUseCase: {ex.Message}");
            }
        }
    }
}
