using Domain.CurrencyExchange.Trades;
using Domain.Repositories.Command.Base;

namespace Domain.Repositories.Command
{
    public interface ICurrencyExchangeTradeCommandRepository : ICommandRepository<CurrencyExchangeTrade>
    {
    }
}
