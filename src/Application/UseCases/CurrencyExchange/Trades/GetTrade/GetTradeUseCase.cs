using Application.Boundaries;
using Domain.Repositories.Query;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrade
{
    public class GetTradeUseCase : IGetTradeUseCase
    {
        private readonly IOutputPort<GetTradeUseCaseOutput> _outputPort;        
        private readonly ICurrencyExchangeTradeQueryRepository _queryRepository;

        public GetTradeUseCase(IOutputPort<GetTradeUseCaseOutput> outputPort,            
            ICurrencyExchangeTradeQueryRepository queryRepository)
        {
            this._outputPort = outputPort;            
            this._queryRepository = queryRepository;
        }
        public async Task Execute(GetTradeUseCaseInput input)
        {
            try
            {
                var exchangeTrade = await _queryRepository.GetByIdAsync(input.Id);                
                _outputPort.Standard(new GetTradeUseCaseOutput(exchangeTrade));
            }
            catch (Exception ex)
            {                
                _outputPort.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
