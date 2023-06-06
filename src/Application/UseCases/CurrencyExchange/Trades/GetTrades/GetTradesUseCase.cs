using Application.Boundaries;
using Domain.Repositories.Query;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrades
{
    public class GetTradesUseCase : IGetTradesUseCase
    {
        private readonly IOutputPort<GetTradesUseCaseOutput> _outputPort;        
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;

        public GetTradesUseCase(IOutputPort<GetTradesUseCaseOutput> outputPort,            
            ICurrencyExchangeTradeQueryRepository queryRepository)
        {
            this._outputPort = outputPort;            
            this._queryRepository = queryRepository;
        }
        public async Task Execute(GetTradesUseCaseInput input)
        {
            try
            {
                var exchangeTrades = await _queryRepository.GetExchangeTradesByClientIdAsync(input.ClientId);
                _outputPort.Standard(new GetTradesUseCaseOutput(exchangeTrades.ToList()));                
            }
            catch (Exception ex)
            {                
                _outputPort.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
