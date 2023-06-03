using Domain.CurrencyExchange;
using Domain.Repositories.Command.Base;

namespace Domain.Repositories.Command
{
    public interface ICurrencyExchangeTradeCommandRepository : ICommandRepository<CurrencyExchangeTrade>
    {
    }
}
