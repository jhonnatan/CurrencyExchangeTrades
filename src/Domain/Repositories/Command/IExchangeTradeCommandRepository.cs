using Domain.ExchangeTrades;
using Domain.Repositories.Command.Base;

namespace Domain.Repositories.Command
{
    public interface IExchangeTradeCommandRepository : ICommandRepository<ExchangeTrade>
    {
    }
}
