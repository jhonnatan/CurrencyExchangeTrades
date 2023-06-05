using AutoMapper;
using Dapper;
using Domain.CurrencyExchange;
using Domain.Repositories.Query;
using Infrastructure.DataAccess.Repositories.Base;
using System.Data;

namespace Infrastructure.DataAccess.Repositories.ExchangeTrade
{
    public class CurrencyExchangeTradeQueryRepository : QueryRepository<CurrencyExchangeTrade>, ICurrencyExchangeTradeQueryRepository
    {       
        public async Task<IReadOnlyList<CurrencyExchangeTrade>> GetAllAsync()
        {            
            var query = "SELECT * FROM \"CurrencyExchange\".\"CurrencyExchangeTrades\"";

            using (var connection = CreateConnection())
            {
                return (await connection.QueryAsync<CurrencyExchangeTrade>(query)).ToList();
            }
        }

        public async Task<CurrencyExchangeTrade> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM \"CurrencyExchange\".\"CurrencyExchangeTrades\" WHERE \"Id\" = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid);

            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<CurrencyExchangeTrade>(query, parameters);
            }
        }

        public async Task<IReadOnlyList<CurrencyExchangeTrade>> GetExchangeTradesByClientIdAsync(Guid clientId)
        {
            var query = "SELECT * FROM \"CurrencyExchange\".\"CurrencyExchangeTrades\" WHERE \"ClientId\" = @ClientId";
            var parameters = new DynamicParameters();
            parameters.Add("ClientId", clientId, DbType.Guid);

            using (var connection = CreateConnection())
            {
                return (await connection.QueryAsync<CurrencyExchangeTrade>(query, parameters)).ToList();
            }
        }

        public async Task<int> GetTradesCountByClientIdLastHourAsync(Guid clientId)
        {
            var query = "SELECT COUNT(*) FROM \"CurrencyExchange\".\"CurrencyExchangeTrades\" " +
                "WHERE \"ClientId\" = @ClientId " +
                "and \"TransactionDate\" BETWEEN NOW() - INTERVAL '24 HOURS' AND NOW()";

            var parameters = new DynamicParameters();
            parameters.Add("ClientId", clientId, DbType.Guid);

            using (var connection = CreateConnection())
            {
                return (await connection.QueryFirstOrDefaultAsync<int>(query, parameters));
            }
        }
    }
}
