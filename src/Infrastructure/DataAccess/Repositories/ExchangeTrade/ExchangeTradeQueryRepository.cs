using AutoMapper;
using Dapper;
using Domain.Repositories.Query;
using Infrastructure.DataAccess.Repositories.Base;
using System.Data;

namespace Infrastructure.DataAccess.Repositories.ExchangeTrade
{
    public class ExchangeTradeQueryRepository : QueryRepository<Domain.ExchangeTrades.ExchangeTrade>, IExchangeTradeQueryRepository
    {
        private readonly IMapper _mapper;

        public ExchangeTradeQueryRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<IReadOnlyList<Domain.ExchangeTrades.ExchangeTrade>> GetAllAsync()
        {
            var query = "SELECT * FROM ExchangeTrade";

            using (var connection = CreateConnection())
            {
                var models = (await connection.QueryAsync<Entities.ExchangeTrade>(query)).ToList();

                return _mapper.Map<IReadOnlyList<Domain.ExchangeTrades.ExchangeTrade>>
                    (await connection.QueryAsync<Entities.ExchangeTrade>(query));
            }
        }

        public async Task<Domain.ExchangeTrades.ExchangeTrade> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM ExchangeTrade WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid);

            using (var connection = CreateConnection())
            {
                return _mapper.Map<Domain.ExchangeTrades.ExchangeTrade>(
                    await connection.QueryFirstOrDefaultAsync<Entities.ExchangeTrade>(query, parameters));
            }
        }

        public async Task<Domain.ExchangeTrades.ExchangeTrade> GetExchangeTradeByClientIdAsync(Guid clientId)
        {
            var query = "SELECT * FROM ExchangeTrade WHERE ClientId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("ClientId", clientId, DbType.String);

            using (var connection = CreateConnection())
            {
                return _mapper.Map<Domain.ExchangeTrades.ExchangeTrade>(
                    await connection.QueryFirstOrDefaultAsync<Entities.ExchangeTrade>(query, parameters));
            }
        }
    }
}
