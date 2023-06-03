using AutoMapper;
using Dapper;
using Domain.CurrencyExchange.Trades;
using Domain.Repositories.Query;
using Infrastructure.DataAccess.Repositories.Base;
using System.Data;

namespace Infrastructure.DataAccess.Repositories.ExchangeTrade
{
    public class CurrencyExchangeTradeQueryRepository : QueryRepository<CurrencyExchangeTrade>, ICurrencyExchangeTradeQueryRepository
    {
        private readonly IMapper _mapper;

        public CurrencyExchangeTradeQueryRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<IReadOnlyList<CurrencyExchangeTrade>> GetAllAsync()
        {
            var query = "SELECT * FROM CurrencyExchangeTrades";

            using (var connection = CreateConnection())
            {
                var models = (await connection.QueryAsync<Entities.CurrencyExchangeTrade>(query)).ToList();

                return _mapper.Map<IReadOnlyList<CurrencyExchangeTrade>>
                    (await connection.QueryAsync<Entities.CurrencyExchangeTrade>(query));
            }
        }

        public async Task<CurrencyExchangeTrade> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM CurrencyExchangeTrades WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid);

            using (var connection = CreateConnection())
            {
                return _mapper.Map<CurrencyExchangeTrade>(
                    await connection.QueryFirstOrDefaultAsync<Entities.CurrencyExchangeTrade>(query, parameters));
            }
        }

        public async Task<IReadOnlyList<CurrencyExchangeTrade>> GetExchangeTradesByClientIdAsync(Guid clientId)
        {
            var query = "SELECT * FROM CurrencyExchangeTrades WHERE ClientId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("ClientId", clientId, DbType.String);

            using (var connection = CreateConnection())
            {
                return _mapper.Map<IReadOnlyList<CurrencyExchangeTrade>>
                    (await connection.QueryAsync<Entities.CurrencyExchangeTrade>(query));
            }
        }

        public async Task<int> GetTradesCountByClientIdLastHourAsync(Guid clientId)
        {
            var query = "SELECT * FROM CurrencyExchangeTrades WHERE ClientId = @id " +
                "and TransactionDate BETWEEN NOW() - INTERVAL '24 HOURS' AND NOW()";

            var parameters = new DynamicParameters();
            parameters.Add("ClientId", clientId, DbType.String);

            using (var connection = CreateConnection())
            {
                return (await connection.QueryAsync<Entities.CurrencyExchangeTrade>(query, parameters)).Count();
            }
        }
    }
}
