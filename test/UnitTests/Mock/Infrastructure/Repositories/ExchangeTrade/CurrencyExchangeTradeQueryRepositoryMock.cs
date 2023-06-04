using Domain.CurrencyExchange;
using Domain.Repositories.Query;
using Moq;
using UnitTests.Builders.CurrencyExchange;

namespace UnitTests.Mock.Infrastructure.Repositories.ExchangeTrade
{
    public class CurrencyExchangeTradeQueryRepositoryMock
    {
        public Mock<ICurrencyExchangeTradeQueryRepository> MockRepository()
        {
            var accountDetailsRepositoryMock = new Mock<ICurrencyExchangeTradeQueryRepository>();

            IReadOnlyList<CurrencyExchangeTrade> data = new List<CurrencyExchangeTrade>()
                {
                    CurrencyExchangeTradeBuilder.New().Build(),
                    CurrencyExchangeTradeBuilder.New().Build(),
                    CurrencyExchangeTradeBuilder.New().Build()
                }.AsReadOnly();

            // GetAllAsync
            accountDetailsRepositoryMock.Setup(i => i.GetAllAsync())
                .Returns(Task.FromResult(data));

            // GetByIdAsync
            accountDetailsRepositoryMock.Setup(i => i.GetByIdAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(CurrencyExchangeTradeBuilder.New().Build()));

            // GetExchangeTradesByClientIdAsync
            accountDetailsRepositoryMock.Setup(i => i.GetExchangeTradesByClientIdAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(data));

            // GetTradesCountByClientIdLastHourAsync
            accountDetailsRepositoryMock.Setup(i => i.GetTradesCountByClientIdLastHourAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(2));

            // GetTradesCountByClientIdLastHourAsync
            accountDetailsRepositoryMock.Setup(i => i.GetTradesCountByClientIdLastHourAsync(new Guid("f40ae9d8-c5bf-415e-bfee-1fb35d435e64")))
                .Returns(Task.FromResult(10));

            return accountDetailsRepositoryMock;
        }
    }
}
