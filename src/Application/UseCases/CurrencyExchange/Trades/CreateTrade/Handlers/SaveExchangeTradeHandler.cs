using Application.Boundaries;
using Domain.CurrencyExchange;
using Domain.Repositories.Command;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class SaveExchangeTradeHandler : Handler<CreateTradeUseCaseInput>
    {
        private readonly ICurrencyExchangeTradeCommandRepository _commandRepository;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;
        private readonly ILogger<SaveExchangeTradeHandler> _logger;

        public SaveExchangeTradeHandler(ICurrencyExchangeTradeCommandRepository commandRepository,
            IOutputPort<CreateTradeUseCaseOutput> outputPort,
            ILogger<SaveExchangeTradeHandler> logger
            )
        {
            this._commandRepository = commandRepository;
            this._outputPort = outputPort;
            this._logger = logger;
        }
        public override async Task ProcessRequest(CreateTradeUseCaseInput input)
        {
            input.CurrencyExchangeTrade = new CurrencyExchangeTrade(
                input.ClientId,
                input.AccountId,
                input.DestinationAccountId,
                input.From,
                input.To,
                input.Amount,
                input.Rate,
                input.ConvertedAmount);

            if (input.CurrencyExchangeTrade.Invalid)
            {
                _logger.LogError("Invalid Model. Unable to perform the transaction");
                _outputPort.Error("Invalid Model. Unable to perform the transaction");
                input.ErrorOccured = true;
                return;
            }
            await _commandRepository.AddAsync(input.CurrencyExchangeTrade);

            sucessor?.ProcessRequest(input);
        }
    }
}
