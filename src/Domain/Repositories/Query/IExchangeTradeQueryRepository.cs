using Domain.ExchangeTrades;
using Domain.Repositories.Query.Base;

namespace Domain.Repositories.Query
{
    public interface IExchangeTradeQueryRepository : IQueryRepository<ExchangeTrade>
    {
        Task<IReadOnlyList<ExchangeTrade>> GetAllAsync();
        Task<ExchangeTrade> GetByIdAsync(Guid id);
        Task<ExchangeTrade> GetExchangeTradeByClientIdAsync(Guid clientId);
    }
}
