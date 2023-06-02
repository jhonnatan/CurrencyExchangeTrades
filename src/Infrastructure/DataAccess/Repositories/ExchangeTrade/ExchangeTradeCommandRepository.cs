using Domain.Repositories.Command;
using Infrastructure.DataAccess.Repositories.Base;

namespace Infrastructure.DataAccess.Repositories.ExchangeTrade
{
    public class ExchangeTradeCommandRepository : CommandRepository<Domain.ExchangeTrades.ExchangeTrade>, IExchangeTradeCommandRepository
    {
        public ExchangeTradeCommandRepository(ExchangeContext exchangeContext) : base(exchangeContext)
        {
        }
    }
}
