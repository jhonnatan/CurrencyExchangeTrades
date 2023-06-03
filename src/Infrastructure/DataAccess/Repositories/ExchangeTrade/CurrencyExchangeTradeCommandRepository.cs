using Domain.CurrencyExchange.Trades;
using Domain.Repositories.Command;
using Infrastructure.DataAccess.Repositories.Base;

namespace Infrastructure.DataAccess.Repositories.ExchangeTrade
{
    public class CurrencyExchangeTradeCommandRepository : CommandRepository<CurrencyExchangeTrade>, ICurrencyExchangeTradeCommandRepository
    {
        public CurrencyExchangeTradeCommandRepository(ExchangeContext exchangeContext) : base(exchangeContext)
        {
        }
    }
}
