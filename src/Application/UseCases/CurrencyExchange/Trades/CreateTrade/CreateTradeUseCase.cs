using Application.Boundaries;
using Domain.Repositories.Command;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCase : ICreateTradeUseCase
    {
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;
        private readonly ICurrencyExchangeTradeCommandRepository _commandRepository;
        private readonly ILogger<CreateTradeUseCase> _logger;

        public CreateTradeUseCase(IOutputPort<CreateTradeUseCaseOutput> outputPort,
            ICurrencyExchangeTradeQueryRepository queryRepository,
            ICurrencyExchangeTradeCommandRepository commandRepository,
            ILogger<CreateTradeUseCase> logger)
        {
            this._outputPort = outputPort;
            this._queryRepository = queryRepository;
            this._commandRepository = commandRepository;
            this._logger = logger;
        }
        public async Task Execute(CreateTradeUseCaseInput input)
        {
            try
            {
                if (input.CurrencyExchangeTrade.Invalid)
                {
                    _logger.LogError("Model Invalid. Unable to perform the transaction.");
                    _outputPort.Error("Model Invalid. Unable to perform the transaction.");
                    return;
                }

                var count = await _queryRepository.GetTradesCountByClientIdLastHourAsync(input.CurrencyExchangeTrade.ClientId);
                if (count > 10)
                {
                    _logger.LogError("The Client has reached the limit of 10 transactions per hour. Unable to perform the transaction.");
                    _outputPort.Error("The Client has reached the limit of 10 transactions per hour. Unable to perform the transaction.");
                    return;
                }

                await _commandRepository.AddAsync(input.CurrencyExchangeTrade);

                _logger.LogInformation("Currency Exchange Trade executed successfully");
                _outputPort.Standard(new CreateTradeUseCaseOutput(input.CurrencyExchangeTrade.Id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the CreateTradeUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the CreateTradeUseCase: {ex.Message}");
            }            
        }
    }
}
