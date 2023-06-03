using Domain.CurrencyExchange;
using Domain.Repositories.Query.Base;

namespace Domain.Repositories.Query
{
    public interface ICurrencyExchangeTradeQueryRepository : IQueryRepository<CurrencyExchangeTrade>
    {
        Task<IReadOnlyList<CurrencyExchangeTrade>> GetAllAsync();
        Task<CurrencyExchangeTrade> GetByIdAsync(Guid id);
        Task<IReadOnlyList<CurrencyExchangeTrade>> GetExchangeTradesByClientIdAsync(Guid clientId);
        Task<int> GetTradesCountByClientIdLastHourAsync(Guid clientId);
    }
}
