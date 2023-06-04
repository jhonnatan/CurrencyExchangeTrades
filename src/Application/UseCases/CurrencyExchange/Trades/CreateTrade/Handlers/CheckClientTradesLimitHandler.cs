using Application.Boundaries;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class CheckClientTradesLimitHandler : Handler<CreateTradeUseCaseInput>
    {
        private readonly ILogger<CheckClientTradesLimitHandler> _logger;
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;

        public CheckClientTradesLimitHandler(ILogger<CheckClientTradesLimitHandler> logger,
            ICurrencyExchangeTradeQueryRepository queryRepository,
            IOutputPort<CreateTradeUseCaseOutput> outputPort)
        {
            this._logger = logger;
            this._queryRepository = queryRepository;
            this._outputPort = outputPort;
        }
        public override async Task ProcessRequest(CreateTradeUseCaseInput input)
        {                        
            var count = await _queryRepository.GetTradesCountByClientIdLastHourAsync(input.ClientId);
            if (count > 10)
            {
                _logger.LogError("The Client has reached the limit of 10 transactions per hour. Unable to perform the transaction.");
                _outputPort.Error("The Client has reached the limit of 10 transactions per hour. Unable to perform the transaction.");
                return;
            }

            sucessor?.ProcessRequest(input);
        }
    }
}
