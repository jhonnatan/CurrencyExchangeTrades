using Application.Boundaries;
using Domain.CurrencyExchange;
using Domain.Repositories.Command;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class SaveExchangeTradeHandler : Handler<CreateTradeUseCaseInput>
    {
        private readonly ICurrencyExchangeTradeCommandRepository _commandRepository;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;        

        public SaveExchangeTradeHandler(ICurrencyExchangeTradeCommandRepository commandRepository,
            IOutputPort<CreateTradeUseCaseOutput> outputPort
            )
        {
            this._commandRepository = commandRepository;
            this._outputPort = outputPort;            
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
                _outputPort.Error("Invalid Model. Unable to perform the transaction", "SaveExchangeTradeHandler");
                input.ErrorOccured = true;
                return;
            }
            await _commandRepository.AddAsync(input.CurrencyExchangeTrade);

            sucessor?.ProcessRequest(input);
        }
    }
}
