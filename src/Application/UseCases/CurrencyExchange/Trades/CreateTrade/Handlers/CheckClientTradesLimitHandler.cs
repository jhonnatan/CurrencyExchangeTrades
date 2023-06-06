using Application.Boundaries;
using Domain.Repositories.Query;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class CheckClientTradesLimitHandler : Handler<CreateTradeUseCaseInput>
    {        
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;

        public CheckClientTradesLimitHandler(ICurrencyExchangeTradeQueryRepository queryRepository,
            IOutputPort<CreateTradeUseCaseOutput> outputPort)
        {            
            this._queryRepository = queryRepository;
            this._outputPort = outputPort;
        }
        public override async Task ProcessRequest(CreateTradeUseCaseInput input)
        {                        
            var count = await _queryRepository.GetTradesCountByClientIdLastHourAsync(input.ClientId);
            if (count >= 10)
            {                
                _outputPort.Error("The Client has reached the limit of 10 transactions per hour. Unable to perform the transaction.", "CheckClientTradesLimitHandler");
                input.ErrorOccured = true;
                return;
            }

            sucessor?.ProcessRequest(input);
        }
    }
}
